using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

    [SerializeField] float timeBeteenSpawns = 1;
    [SerializeField] float spawnDistance;
    [SerializeField] Nucleon[] nucleonPrefabs;


	void SpawnNucleon () {
        Nucleon spawn = Instantiate<Nucleon>( nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)] );
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}
	
    float timeSindsLastSpawn;
	void FixedUpdate () {
		timeSindsLastSpawn += Time.deltaTime;
        if(timeSindsLastSpawn >= timeBeteenSpawns) {
            timeSindsLastSpawn -= timeSindsLastSpawn;
            SpawnNucleon();
        }
	}


}
