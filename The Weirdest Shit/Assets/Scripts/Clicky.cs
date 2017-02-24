using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clicky : MonoBehaviour {
	public Vector3 lastHit;

	// Use this for initialization
	void Start () {
		lastHit = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		bool click = Input.GetMouseButtonDown(0);
		DrawCross(lastHit);
		if (click) {
			DoClick();
		}

	}

	public void DoClick(){
		RaycastHit rch;
		if (Physics.Raycast(transform.position, transform.forward, out rch)){
			Debug.Log("Yo");
			lastHit = rch.point;
			Button butt = rch.collider.GetComponent<Button>();

			if (butt != null)
				butt.onClick.Invoke();
		}
	}


	void DrawCross(Vector3 pos, float size = 1){
		Debug.DrawLine(pos+Vector3.up*size,pos+Vector3.down*size, Color.blue);
		Debug.DrawLine(pos+Vector3.left*size,pos+Vector3.right*size, Color.green);
		Debug.DrawLine(pos+Vector3.back*size,pos+Vector3.forward*size, Color.red);
	}
}
