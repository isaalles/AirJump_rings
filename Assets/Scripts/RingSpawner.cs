using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingSpawner : MonoBehaviour {

	// ring prefab
	public GameObject ringPrefab;
	public int ringSize;

	private GameObject bird;

	public List<GameObject> rings;

	Vector3 offset = new Vector3 (400,0,400);

	// Use this for initialization
	void Start () {
		rings = new List<GameObject>();
		//Physics.IgnoreLayerCollision(0,8);

		bird = GameObject.Find("Bird");

		//rings = new GameObject[ringSize];
		for (int i=0; i<ringSize; i++)
		{
			Vector3 position = new Vector3 (
				Random.value * 1200,
				Random.value * 1200,
				Random.value * 1200

				// the values below take into account a sphere collider on the Ring Spawner GameObject
				// I am not using them now as the collider gets in conflict with the bird
				// and I don't want to get into the collision layers and all that...

//				Random.value * collider.bounds.size.x/2,
//				Random.value * collider.bounds.size.y/2,
//				Random.value * collider.bounds.size.z/2
				)-offset;


			GameObject ring = Instantiate(ringPrefab, transform.position, bird.transform.rotation) as GameObject;
			ring.transform.parent = transform;
			ring.transform.localPosition = position;
			rings.Add(ring);
			//rings[i] = ring;
		}

	}
	
	// Update is called once per frame
	void Update () {
		// always have ringSize rings
		if (rings.Count < ringSize) {

			{
				Vector3 position = bird.rigidbody.velocity * Random.value;
				GameObject ring = Instantiate(ringPrefab, transform.position, bird.transform.rotation) as GameObject;
				ring.transform.parent = transform;
				ring.transform.localPosition = position;
				rings.Add(ring);
			}
		}
	

	}
	
}
