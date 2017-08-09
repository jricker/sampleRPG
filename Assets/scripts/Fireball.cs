using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }
	Vector3 SpawnPosition;

    private void Start()
    {
		Range = 20f;
		Damage = 4;
		SpawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction*200f);
    }

	void Update()
	{
		if (Vector3.Distance(SpawnPosition, transform.position) >= Range) {
			Extinguish ();
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Enemy") {
			col.transform.GetComponent<IEnemy> ().TakeDamage (Damage);
		}
		Extinguish ();
	}

	void Extinguish()
	{
		Destroy (gameObject);
	}


}
