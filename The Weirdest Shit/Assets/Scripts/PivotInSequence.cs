using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PopInUI))]
public class PivotInSequence : MonoBehaviour {

	PopInUI piu;
	public float delay;
	float timeTill;

	public PopInUI childPiu;

	// Use this for initialization
	void Start () {
		piu = GetComponent<PopInUI>();
		if (childPiu == null)
			childPiu = GetComponentInChildren<PopInUI>();
		timeTill = delay;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(timeTill);
		Debug.Log(childPiu.name);
		if (childPiu.popped != piu.popped){
			Debug.Log("counting");
			timeTill -= Time.deltaTime;
			if (timeTill<=0){
				childPiu.popped = piu.popped;
			}
		} else {
			Debug.Log("resetting");
			timeTill = delay;
		}
	}
}
