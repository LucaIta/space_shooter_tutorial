using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	public float speed;

    private Rigidbody rb;


	private void Start() 
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
		// Debug.Log("transform.forward * speed = " + transform.forward * speed);
	}
}
