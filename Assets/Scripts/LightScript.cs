using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    private GameMasterScript eventMasterScript;
    private Animator anim;

    void OnEnable() {
        SetInitialReferences();
        eventMasterScript.spawnEnemies += enemyLights;
        eventMasterScript.enemiesCleared += normalLights;
    }

    void OnDisable() {
        eventMasterScript.spawnEnemies -= enemyLights;
        eventMasterScript.enemiesCleared -= normalLights;
    }

    void enemyLights() {
        anim.SetBool("enemiesSpawn", true);
    }

    void normalLights() {
        anim.SetBool("enemiesSpawn", false);
    }

    void SetInitialReferences() {
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        anim = gameObject.GetComponent<Animator>();
    }
}
