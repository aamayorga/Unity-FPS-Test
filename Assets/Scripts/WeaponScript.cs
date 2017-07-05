using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    private GameMasterScript eventMasterScript;
    private GameObject weapon;

    void OnEnable() {
        SetInitialReferences();
        eventMasterScript.spawnEnemies += GiveWeapon;
    }

    void OnDisable() {
        eventMasterScript.spawnEnemies -= GiveWeapon;
    }

    // Use this for initialization
    void SetInitialReferences() {
        eventMasterScript = GameObject.Find("GameMaster").GetComponent<GameMasterScript>();
        weapon = transform.Find("FirstPersonCharacter/Weapon").gameObject;
    }

    void GiveWeapon() {
        weapon.SetActive(true);
    }
}
