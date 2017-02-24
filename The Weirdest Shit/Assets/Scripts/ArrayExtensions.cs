using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions {

	public static T pickRandom<T>(this T[] array){
		return array[Random.Range(0,array.Length)];
	}

}
