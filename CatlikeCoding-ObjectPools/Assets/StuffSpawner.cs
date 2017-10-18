using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

	[SerializeField]private float timeBetweenSpawns;
    [SerializeField]private Stuff[] stuffPrefabs;

    float timeSinceSpawn;

    void FixedUpdate () {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeBetweenSpawns) {
			timeBetweenSpawns -= timeBetweenSpawns;
            SpawnStuff ();
        }
    }

    void SpawnStuff () {
        Stuff spawn = Instantiate<Stuff> (stuffPrefabs[Random.Range (0, stuffPrefabs.Length)]);
        spawn.transform.localPosition = transform.position;
    }
}