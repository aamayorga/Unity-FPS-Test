using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {

    public GameObject grenadePrefab;
    public float propulsionForce;

    private Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1")) {
            SpawnGrenade();
        }
	}

    void SpawnGrenade() {
        GameObject gNade = (GameObject)Instantiate(grenadePrefab, myTransform.TransformPoint(0, 0, 0.5f), myTransform.rotation);
        gNade.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);
        Destroy(gNade, 10);
    }
}
