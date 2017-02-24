using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class FlipOut : MonoBehaviour {

	BoxCollider bc;

	public bool flipOut{
		get {
			if (bc==null){
				bc = GetComponent<BoxCollider>();
			}
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
			return !GeometryUtility.TestPlanesAABB(planes, bc.bounds);
		}
	}

}
