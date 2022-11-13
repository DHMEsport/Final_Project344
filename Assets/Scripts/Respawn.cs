using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float spawnValue;

     public void UpdateSpawnValue(int change)
    {
        spawnValue += change;
        UpdateSpawnValue();
    }

     private void UpdateSpawnValue()
     {
         Debug.Log(spawnValue);
     }

     public void Live()
    {
        if (spawnValue >= 0)
        {
            player.transform.position = SpawnPoint.transform.position;
            spawnValue = spawnValue - 1;
            UpdateSpawnValue();
        }
    }
    private void Update()
    {
        Live();
    }
}
