using UnityEngine;
using System.Collections;

public class Flocking : MonoBehaviour {

	public float speed = 20f;
	private GameObject target;
	
	void Start ()
	{
		target = GameObject.Find("FlockTarget");
	}

	void Update() {
		transform.LookAt(target.transform);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

}
