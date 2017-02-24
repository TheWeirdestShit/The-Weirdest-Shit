using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ShakeParams {

	[Range(0,10)]
	public float frequency;

	[Range(0,1)]
	public float amplitude;

}

public class Shake : MonoBehaviour {

	public ShakeParams[] positionShakes;
	public ShakeParams[] rotationShakes;
	Vector3[] positionPhases;
	Vector3[] rotationPhases;

	Vector3 originalPosition;
	Vector3 originalRotation;

	// Use this for initialization
	void Start () {
		positionPhases = new Vector3[positionShakes.Length];
		for (int i=0; i<positionPhases.Length; i++){
			positionPhases[i] = new Vector3(
				Random.value*Mathf.PI*2,
				Random.value*Mathf.PI*2,
				Random.value*Mathf.PI*2
			);
		}
		rotationPhases = new Vector3[rotationShakes.Length];
		for (int i=0; i<rotationPhases.Length; i++){
			rotationPhases[i] = new Vector3(
				Random.value*Mathf.PI*2,
				Random.value*Mathf.PI*2,
				Random.value*Mathf.PI*2
			);
		}
		originalPosition = transform.localPosition;
		originalRotation = transform.localRotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = originalPosition;
		for (int i = 0; i<positionShakes.Length; i++){
			ShakeParams param = positionShakes[i];
			Vector3 phase = positionPhases[i];
			pos += new Vector3(
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.x)*param.amplitude,
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.y)*param.amplitude,
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.z)*param.amplitude
			);
		}
		transform.localPosition = pos;

		Vector3 rot = originalRotation;
		for (int i = 0; i<rotationShakes.Length; i++){
			ShakeParams param = rotationShakes[i];
			Vector3 phase = rotationPhases[i];
			rot += new Vector3(
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.x)*param.amplitude,
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.y)*param.amplitude,
				Mathf.Sin(Time.time*Mathf.PI*2*param.frequency+phase.z)*param.amplitude
			);
		}
		transform.localRotation = Quaternion.Euler(rot);
	}
}
