using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEncounter : Encounter
{
    [SerializeField] private float _initialDelay = 1f;
    [SerializeField] private float _encounterDuration = 15f;
    [SerializeField] private float _enemySpawnTime = 1f;
    [SerializeField] private EnemyController[] _enemyPrefabs;

    public override void StartEncounter()
    {
        base.StartEncounter();

        StartCoroutine(TimedEncounterRoutine());
    }

    private IEnumerator TimedEncounterRoutine()
    {
        // initial delay
        yield return new WaitForSeconds(_initialDelay);

        // initialize timers
        float encounterTimer = 0f;
        float nextSpawnTime = Time.time + _enemySpawnTime;

        // spawn enemies continually while encounter is ongoing
        while(encounterTimer < _encounterDuration)
        {
            encounterTimer += Time.deltaTime;

            // update objective
            float remainingTime = Mathf.CeilToInt(_encounterDuration - encounterTimer);
            UpdateObjective($"Time remaining: {remainingTime}s");

            // spawn enemy when next time reached
            if(Time.time > nextSpawnTime)
            {
                // set next spawn time
                nextSpawnTime = Time.time + _enemySpawnTime;

                // spawn enemy
                int index = Random.Range(0, _enemyPrefabs.Length);
                EnemyController enemyPrefab = _enemyPrefabs[index];
                SpawnEnemy(enemyPrefab);
            }

            yield return null;
        }

        // wait for enemies to be killed
        UpdateObjective("Defeat remaining enemies.");
        while (CurrentEnemyCount > 0) yield return null;

        // wrap up
        FinishEncounter();
        UpdateObjective("");
    }
}