using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

// abstract prevents us from using encounter directly, we have to inherit
public abstract class Encounter : MonoBehaviour
{
    [SerializeField, InlineButton(nameof(FindWaypoints), "Find")] private List<Waypoint> _waypoints = new List<Waypoint>();

    // used in editor to configure encounters
    public UnityEvent OnEncounterStarted;
    public UnityEvent OnEncounterFinished;
    public UnityEvent<string> OnUpdateObjective;

    // track encounter enemies
    private List<EnemyController> _currentEnemies = new List<EnemyController>();
    public int CurrentEnemyCount => _currentEnemies.Count;

    private void OnValidate()
    {
        FindWaypoints();
    }

    private void FindWaypoints()
    {
        // .ToList() can be expensive, but we're doing this during edit mode anyway
        _waypoints = GetComponentsInChildren<Waypoint>().ToList();
    }

    public virtual void StartEncounter()
    {
        OnEncounterStarted.Invoke();
    }

    public virtual void FinishEncounter()
    {
        OnEncounterFinished.Invoke();
    }

    // update HUD text from child class
    protected void UpdateObjective(string message)
    {
        OnUpdateObjective.Invoke(message);
    }

    protected Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, _waypoints.Count);
        return _waypoints[randomIndex].transform;
    }

    protected void SpawnEnemy(EnemyController enemy)
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        // if we pass a component in as a prefab to spawn, it automatically casts to that type
        EnemyController spawned = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation, transform);

        // add spawned enemy to current list
        _currentEnemies.Add(spawned);

        // add listener to remove enemy from list once killed
        spawned.GetComponent<Health>().OnDeath.AddListener(OnEnemyKilled);
    }

    private void OnEnemyKilled(DamageInfo damageInfo)
    {
        // check for valid enemy and ensure it's in list
        if(damageInfo.Victim.TryGetComponent(out EnemyController enemy) && _currentEnemies.Contains(enemy))
        {
            // remove from list and clean up event listener
            _currentEnemies.Remove(enemy);
            enemy.GetComponent<Health>().OnDeath.RemoveListener(OnEnemyKilled);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // draw spheres around all waypoints
        Gizmos.color = Color.yellow;
        if(_waypoints != null)
        {
            foreach(Waypoint waypoint in _waypoints)
            {
                Gizmos.DrawWireSphere(waypoint.transform.position, 0.5f);
            }
        }

        // draw around enemies
        Gizmos.color = Color.red;
        if(_currentEnemies != null)
        {
            foreach (EnemyController enemy in _currentEnemies)
            {
                Gizmos.DrawWireSphere(enemy.transform.position, 1.5f);
            }
        }
    }
}