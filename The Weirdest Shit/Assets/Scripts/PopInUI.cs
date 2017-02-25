using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopInUI : MonoBehaviour {

	public AudioClip popIn;
	public AudioClip popOut;
	AudioSource asource;
	bool wasPopped = false;

	public Vector3 fromScale;
	public Vector3 toScale;

	public Vector3 fromRotation;
	public Vector3 toRotation;

	public float spring;
	public float damp;

	float position;
	float scalePos;
	float velocity;

	public bool popped;

	RectTransform rct;

	// Use this for initialization
	void Start () {
		rct = GetComponent<RectTransform>();
		position = (popped ? 1 : 0);
		scalePos = position;
		velocity = 0;
		wasPopped = popped;
		asource = GetComponent<AudioSource>();
	}
	
	void FixedUpdate(){
		float error = (popped ? 1 : 0) - position;

		velocity += error * spring * Time.fixedDeltaTime;
		velocity -= velocity * damp * Time.fixedDeltaTime;

		if (asource!=null && popped != wasPopped){
			if (popped){
				if (popOut!=null)
					asource.clip = popOut;
			} else {
				if (popIn!=null)
					asource.clip = popIn;
			}
			wasPopped = popped;
			asource.Play();
		}

	}

	// Update is called once per frame
	void Update () {

		position += velocity * Time.deltaTime;
		position = Mathf.Max(position, 0);

		if (popped){
			scalePos = Mathf.Max(scalePos, position);
		} else {
			scalePos = Mathf.Min(scalePos, position);
		}

		if (rct != null)
		{
			rct.localScale = Vector3.Lerp(fromScale, toScale, scalePos);
			rct.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(fromRotation), Quaternion.Euler(toRotation), position);
		} else {
			transform.localScale = Vector3.Lerp(fromScale, toScale, scalePos);
			transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(fromRotation), Quaternion.Euler(toRotation), position);
		}
	}



}
