using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Rigidbody Prefab;

    //If this trigger object is triggered, the jar will frop from the spawn point.
    private void OnTriggerEnter()
    {
        Rigidbody RigidPrefab;
        RigidPrefab = Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
        
    }

}
