﻿using UnityEngine;
using System.Collections;

public class Wings : MonoBehaviour {

	private Transform leftWing;
	private Transform rightWing;
	public float flapAmp = 40f;
	public float flapFreq = 5f;
	private float t;


	// Use this for initialization
	void Start () {
		leftWing = transform.FindChild ("leftWing");
		rightWing = transform.FindChild ("rightWing");
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation=GameObject.Find("Bird").transform.rotation * Quaternion.Euler(0,180,0);
		leftWing.transform.localEulerAngles = new Vector3 (0, 0, Mathf.Sin (t) * flapAmp);
		rightWing.transform.localEulerAngles = new Vector3 (180, 0, Mathf.Sin (t) * flapAmp);

		t+=flapFreq*Time.deltaTime;
	}
}
