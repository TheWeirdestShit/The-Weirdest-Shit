using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlipOut))]
public class RotateOnFlipout : MonoBehaviour {

	FlipOut fo;

	public Vector3[] rotations;

	// Use this for initialization
	void Start () {
		fo = GetComponent<FlipOut>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fo.flipOut){
			transform.rotation = Quaternion.Euler(rotations.pickRandom());
		}
	}
}
