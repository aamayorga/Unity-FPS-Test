using UnityEngine;
using System.Collections;

public class GrenadeExplosion : MonoBehaviour {

    private Collider[] hitColliders;
    private float destroyTime = 5;

    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;

	void OnCollisionEnter(Collision col) {
        ExplosionWork(col.contacts[0].point);
        Destroy(gameObject);
    }

    void ExplosionWork(Vector3 explosionPoint) {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

        foreach(Collider hitCol in hitColliders) {

            if(hitCol.GetComponent<UnityEngine.AI.NavMeshAgent>() != null) {
                hitCol.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            }

            if(hitCol.GetComponent<Rigidbody>() != null) {
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }

            if(hitCol.CompareTag("Enemy")) {
                GameObject enemy = hitCol.transform.root.gameObject;
                enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                enemy.GetComponent<Rigidbody>().isKinematic = false;
                enemy.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                Destroy(enemy, destroyTime);
            }
        }
    }
}
