using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

    public delegate void GeneralEvent();
    public event GeneralEvent spawnEnemies;
    public event GeneralEvent enemiesCleared;
    
    // Canvas
    public GameObject canvas;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void CallMyGeneralEvent() {
        if (spawnEnemies != null) {
            spawnEnemies();
        }
    }

    public void EnemiesAreGone() {
        if (enemiesCleared != null) {
            enemiesCleared();
        }
    }
}
