using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	GameObject bird;

	// Use this for initialization
	void Start () {
		bird = GameObject.Find("Bird");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(bird.transform);
	}
}
