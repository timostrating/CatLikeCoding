using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

    [SerializeField]
    [Range(0,10)]
    float force = 10;

    Rigidbody body;

	void Awake () {
		body = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update () {
		body.AddForce(transform.localPosition * -force);
	}
}
