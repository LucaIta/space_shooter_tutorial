using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// we will use tumble to control the maximum speed of the rotation
	public float tumble;
	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		// angular velocity control how fast an object is rotating. We set its value at start, so it immediately starts rotating.
		// Random.insideUnitSphere gives use a random vector 3 value, it randomize individually the x,y and z, so it's great for random rotation. Its a point in a sphere with radius 1, so the max value should be 1.
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
