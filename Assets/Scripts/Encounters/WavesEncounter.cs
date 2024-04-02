using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesEncounter : Encounter
{
    [SerializeField] private EnemyWave[] _waves;

    public override void StartEncounter()
    {
        base.StartEncounter();

        StartCoroutine(WavesEncounterRoutine());
    }

    private IEnumerator WavesEncounterRoutine()
    {
        // intro message
        UpdateObjective("Zombies Incoming!");

        // spawn all waves sequentially
        for (int i = 0; i < _waves.Length; i++)
        {
            // pause while currently fighting wave
            while (CurrentEnemyCount > 0) yield return null;

            // get current wave
            EnemyWave wave = _waves[i];

            // wait for initial delay
            yield return new WaitForSeconds(wave.InitialDelay);

            // update objective text with current count
            string message = $"Remaining Wave(s): {_waves.Length - i}";
            UpdateObjective(message);

            // spawn each enemy, waiting in between
            foreach (EnemyController enemyPrefab in wave.EnemyPrefabs)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(wave.SpawnDelay);
            }
        }

        UpdateObjective("Defeat remaining enemies.");

        // wait for remaining enemies to die
        while (CurrentEnemyCount > 0) yield return null;

        // wrap up
        FinishEncounter();
        UpdateObjective("");
    }
}