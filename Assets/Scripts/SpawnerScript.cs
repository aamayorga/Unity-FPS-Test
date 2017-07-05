using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public GameObject objectToSpawn;
    public int numberOfEnemies;

    private bool checkingForEnemies = true;
    private bool enemiesHaveSpawned = false;
    private float spawnRadius = 2;
    private GameMasterScript eventMasterScript;
    private Vector3 spawnPosition;

    void Update() {
        if (checkingForEnemies && enemiesHaveSpawned) {
            CheckForEnemies();
        }
    }

    void OnEnable() {
        SetInitialReferences();
        eventMasterScript.spawnEnemies += SpawnEnemies;
    }

    void OnDisable() {
        eventMasterScript.spawnEnemies -= SpawnEnemies;
    }

    void SpawnEnemies() {
        for (int i = 0; i < numberOfEnemies; i++) {
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        enemiesHaveSpawned = true;
    }

    void CheckForEnemies() {
        if (GameObject.FindGameObjectWithTag("Enemy") == null) {
            eventMasterScript.EnemiesAreGone();
            checkingForEnemies = false;
        }
    }

    void SetInitialReferences() {
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
    }
}
