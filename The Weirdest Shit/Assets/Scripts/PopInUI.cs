﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopInUI : MonoBehaviour {

	public Vector3 fromScale;
	public Vector3 toScale;

	public Vector3 fromRotation;
	public Vector3 toRotation;

	public float spring;
	public float damp;

	float position;
	float velocity;

	public bool popped;

	RectTransform rct;

	// Use this for initialization
	void Start () {
		rct = GetComponent<RectTransform>();
		position = (popped ? 1 : 0);
		velocity = 0;
	}
	
	void FixedUpdate(){
		float error = (popped ? 1 : 0) - position;

		velocity += error * spring * Time.fixedDeltaTime;
		velocity -= velocity * damp * Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update () {

		position += velocity * Time.deltaTime;
		position = Mathf.Max(position, 0);
		if (rct != null)
		{
			rct.localScale = Vector3.Lerp(fromScale, toScale, position);
			rct.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(fromRotation), Quaternion.Euler(toRotation), position);
		} else {
			transform.localScale = Vector3.Lerp(fromScale, toScale, position);
			transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(fromRotation), Quaternion.Euler(toRotation), position);
		}
	}



}