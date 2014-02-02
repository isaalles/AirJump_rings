using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockController : MonoBehaviour {

	public float speed = 5;

	public int flockSize = 20;
	public GameObject prefab;
	public GameObject target;

	private Vector3 direction;
	
	private List<GameObject> birds;
	
	void Start()
	{
		birds = new List<GameObject>();
		for (int i=0; i<flockSize; i++)
		{
			Vector3 position = new Vector3 (
				Random.value * 1200,
				Random.value * 1200,
				Random.value * 1200
				);
			
			GameObject bird = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
			bird.transform.parent = transform;
			bird.transform.localPosition = position;
			bird.AddComponent<Flocking>();
			//bird.GetComponent<Flocking>().SetController (gameObject);
			birds.Add(bird);
		}

		direction = new Vector3 (
			Random.value * 300,
			Random.value * 600,
			Random.value * 800);
		direction = direction.normalized;

	}




	void Update ()
	{

		if (target.transform.position.x > 1000 || 
		    target.transform.position.y > 900 ||
		    target.transform.position.z > 1000)
		{
			direction = new Vector3 (
				Random.value * 300,
				Random.value * 600,
				Random.value * 800);
			direction = direction.normalized;
		}
		else
			target.rigidbody.position += direction * (Time.deltaTime * speed);
	

	}
}
