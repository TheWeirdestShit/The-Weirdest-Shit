using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorImageOnFlipout : MonoBehaviour {

	public Texture2D[] images;

	FlipOut fo;
	Projector proj;

	// Use this for initialization
	void Start () {
		fo = GetComponent<FlipOut>();
		proj = GetComponent<Projector>();

		Material mat = new Material(proj.material);
		mat.SetTexture("_ShadowTex", images.pickRandom());
		proj.material = mat;
	}
	
	// Update is called once per frame
	void Update () {
		if (fo.flipOut){
			Material mat = new Material(proj.material);
			mat.SetTexture("_ShadowTex", images.pickRandom());
			proj.material = mat;
		}
	}
}
