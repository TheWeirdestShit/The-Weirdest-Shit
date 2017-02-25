using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeClick : MonoBehaviour {

	public Image gazeDisplay;
	public float clickIn;
	float time;
	
	// Update is called once per frame
	void Update () {
		bool isUI = false;
		RaycastHit rch;
		if (Physics.Raycast(transform.position, transform.forward, out rch)){
			Button butt = rch.collider.GetComponent<Button>();

			if (butt != null){
				time = time-Time.deltaTime;
				if (time<=0){
					time = clickIn;
					butt.onClick.Invoke();
				}
			} else {
				time = clickIn;
			}
		} else {
			time = clickIn;
		}
		if (gazeDisplay!=null){
			Material mat = new Material(gazeDisplay.material);
			mat.SetFloat("_Value",Mathf.Clamp01(1-(time/clickIn)));
			gazeDisplay.material = mat;
		}
	}
}
