using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour {

	public Texture2D cursor;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursor, Vector2.one*2, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
