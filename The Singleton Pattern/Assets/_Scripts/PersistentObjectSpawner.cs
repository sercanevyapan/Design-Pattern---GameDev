using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    //CONFIG DATA
    [Tooltip("This prefab will only spawned once persisted between" +
    "scenes.")]
    [SerializeField] GameObject persistentObjectPrefab = null;

    //PRIVATE STATE
    static bool hasSpawned = false;

    //PRIVATE
    private void Awake() {
        if(hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
