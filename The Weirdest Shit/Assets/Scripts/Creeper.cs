using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PopInUI))]
public class Creeper : MonoBehaviour {

	PopInUI piu;
	public GameObject flash;
	public float minTime;
	public float maxTime;
	public float creepTime;
	public float firstCreep = 15;
	float rpick;
	float time;

	// Use this for initialization
	void Start () {
		piu = GetComponent<PopInUI>();
		Reset();
		time = -firstCreep;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		float teatime = Mathf.LerpUnclamped(minTime, maxTime, rpick);
		if (flash!=null)
			flash.SetActive(time>teatime+Mathf.Lerp(0,creepTime,0.45f) && time<teatime+Mathf.Lerp(0,creepTime,0.55f));
		if (time<teatime){
			piu.popped = false;
		} else {
			piu.popped = true;
			if (time>teatime+creepTime){
				Reset();
			}
		}
	}

	void Reset(){
		rpick = Random.value;
		time = 0;
	}
}
