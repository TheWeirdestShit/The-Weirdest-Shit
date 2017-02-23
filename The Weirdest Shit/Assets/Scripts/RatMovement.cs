using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour 
{

	public GameObject Target;
	public float Speed;

	private Vector3 targetPos;


	// Use this for initialization
	void Start () 
	{
		targetPos = Target.transform.position;
	}
	
	//
	void Update () 
	{
		if( transform.position != targetPos)
		{
			transform.position = Vector3.MoveTowards( transform.position, targetPos, Speed * Time.deltaTime);
		}
	}
}
