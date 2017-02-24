using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightSwitcher : MonoBehaviour {

	public GameObject normal;
	public GameObject hover;
	
	// Update is called once per frame
	void Update () {
		bool isUI = false;
		RaycastHit rch;
		if (Physics.Raycast(transform.position, transform.forward, out rch)){
			Button butt = rch.collider.GetComponent<Button>();

			if (butt != null)
				isUI = true;
		}
		normal.SetActive(!isUI);
		hover.SetActive(isUI);
	}
}
