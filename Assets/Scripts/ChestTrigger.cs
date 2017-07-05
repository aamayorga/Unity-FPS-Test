using UnityEngine;
using System.Collections;

public class ChestTrigger : MonoBehaviour {

    // The chest GameObject and the name of the object we need to find, incase we change the name later

    private GameObject chest;
    private GameMasterScript eventMasterScript;

	// Use this for initialization
	void Start () {
        chest = GameObject.Find("Chest");
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            // Open Chest Animation
            chest.GetComponent<Animator>().SetTrigger("OpenChest");

            eventMasterScript.CallMyGeneralEvent();
            Destroy(gameObject);
        }
    }
}
