using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour {

	Rigidbody body;

	void Awake () {
		body = GetComponent<Rigidbody>();
	}
}
