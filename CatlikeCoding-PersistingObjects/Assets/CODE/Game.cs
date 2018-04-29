using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public Transform prefab;

	public KeyCode createKey = KeyCode.C;
	public KeyCode newGameKey = KeyCode.N;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(createKey))
			CreateObject();

		if (Input.GetKeyDown(newGameKey))
			BeginNewGame();
	}

	void CreateObject() {
		Transform t = Instantiate(prefab);
		t.localPosition = Random.insideUnitSphere * 5;
		t.localRotation = Random.rotation;
		t.localScale = Vector3.one * Random.Range(0.1f, 1f);
	}

	void BeginNewGame() {

	}
}
