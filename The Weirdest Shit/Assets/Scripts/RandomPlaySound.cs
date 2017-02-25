using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomPlaySound : MonoBehaviour {

	AudioSource asource;
	public AudioClip[] ac;
	public float minTime;
	public float maxTime;
	float time;

	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource>();
		time = Mathf.Lerp(minTime, maxTime, Random.value);
	}
	
	// Update is called once per frame
	void Update () {
		if (!asource.isPlaying){
			time -= Time.deltaTime;
			if (time<=0){
				asource.clip = ac.pickRandom();
				asource.Play();
				time = Mathf.Lerp(minTime, maxTime, Random.value);
			}
		}
	}
}
