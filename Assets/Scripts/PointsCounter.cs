using UnityEngine;
using System.Collections;

public class PointsCounter : MonoBehaviour {

	public float score = 0;

	private AudioSource myAudioSrc;
	public AudioClip swoosh;

	public GameObject ringSpawner;
	int ringIndex;

	void Awake() {
		myAudioSrc = this.GetComponentInChildren<AudioSource>();
		//rings = transform.parent.GetComponent<RingSpawner>().rings;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider C) {

		if (C.transform.tag == "ring") {

			score += 10;
			myAudioSrc.PlayOneShot(swoosh);
			//(C.gameObject.GetComponent("Halo") as Behaviour).enabled = true;
			for (int i = 0; i<ringSpawner.GetComponent<RingSpawner>().ringSize; i++)
			{
				if (C.transform.gameObject == ringSpawner.GetComponent<RingSpawner>().rings[i]) {
				    Debug.Log("C index: " + i);
					ringIndex = i;
				}
			}
		} // end if
		
	}

	void OnTriggerExit(Collider C) {
		if (C.tag == "ring") {
			//
			//ringSpawner.GetComponent<RingSpawner>().ringSize -= 1;
			Debug.Log("a: " + ringSpawner.GetComponent<RingSpawner>().rings.Count);
			Destroy(C.gameObject);
			ringSpawner.GetComponent<RingSpawner>().rings.RemoveAt(ringIndex);
			//ringSpawner.GetComponent<RingSpawner>().rings
			Debug.Log("a: " + ringSpawner.GetComponent<RingSpawner>().rings.Count);

		} // end if
	}

	void OnGUI () {
		// this GUI is not stanrdadized for Oculus Rift
		// that is why I added a little sound effect
		//GUI.Label(new Rect (10,10,100,20), score.ToString());
	}


}
