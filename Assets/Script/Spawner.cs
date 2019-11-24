using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

public GameObject obstacle;
public GameObject parentObject;
public GameObject objectRotation;

public float timeBtwSpawn;
public float minimumSpawnTime;
public float maximumSpawnTime;

private float startTimeBtwSpawn;


 void Start() 
{ 
    startTimeBtwSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);  
}


void Update()
{
    
    if (timeBtwSpawn <= 0) {
        var myObject = Instantiate(obstacle, transform.position, Quaternion.identity);
        myObject.transform.parent = parentObject.transform;
        myObject.transform.rotation = objectRotation.transform.rotation; 
        
        startTimeBtwSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        Debug.Log(startTimeBtwSpawn);
        timeBtwSpawn = startTimeBtwSpawn;
    }   else {
            timeBtwSpawn -= Time.deltaTime;
        }
}

}
