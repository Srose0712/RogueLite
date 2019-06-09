using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject[] asteroidSpawner;
    float maxTime = 5;
    float minTime = 2;

    private float time;
    private float spawnTime;

	// Use this for initialization
	void Start () {

        SetRandomTime();
        time = minTime;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        time += Time.deltaTime;

        while(time > spawnTime){

            AsterSpawner();
         
        }
	}

    void AsterSpawner(){

        time = 0;
        int i = Random.Range(0, asteroidSpawner.Length);
        GameObject asterClone = Instantiate(asteroidSpawner[i]);
        asterClone.transform.position = Random.insideUnitCircle * 10;

    }

    void SetRandomTime(){

        spawnTime = Random.Range(minTime, maxTime);

    }
}
