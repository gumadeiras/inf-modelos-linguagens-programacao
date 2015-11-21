using UnityEngine;
using System.Collections;
using System;

public static class ShotsController {

	public static Func<A, Func<B, R>> Curry<A, B, R>(this Func<A, B, R> f)
	{
		return a => b => f(a, b);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
