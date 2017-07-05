using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    private GameMasterScript eventMasterScript;
    private Animator anim;

    void OnEnable() {
        SetInitialReferneces();
        eventMasterScript.spawnEnemies += MovePlatforms;
    }

    void OnDisable() {
        eventMasterScript.spawnEnemies -= MovePlatforms;
    }
    
	void SetInitialReferneces () {
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        anim = GetComponent<Animator>();
	}

    void MovePlatforms  () {
        anim.SetTrigger("enemiesSpawn");

    }
}
