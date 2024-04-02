using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Monobehaviours are serializable by default
// normal classes aren't, we need to add the attribute: Serializable
[System.Serializable]
public class EnemyWave
{
    public float InitialDelay;              // delay before wave starts
    public float SpawnDelay;                // delay in between enemies spawning
    public EnemyController[] EnemyPrefabs;  // enemies to spawn
}