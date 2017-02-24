using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PopDelay {
	public PopInUI piu;
	public float turnOn;
	public float turnOff;
}

public class PopSequencer : MonoBehaviour {

	public bool popped;
	public PopDelay[] pops;

	bool prev;
	float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (prev != popped){
			prev = popped;
			time = 0;
		}
		time += Time.deltaTime;
		for (int i = 0; i<pops.Length; i++){
			PopDelay pop = pops[i];
			if (time > (popped ? pop.turnOn : pop.turnOff)){
				pop.piu.popped = popped;
			}
		}
	}
}
