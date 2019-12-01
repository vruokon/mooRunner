using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

public GameObject obstacle;
public GameObject parentObject;
public GameObject objectRotation;

private static float j;

public float timeBtwSpawn;
public float minimumSpawnTime;
public float maximumSpawnTime;
public float absoluteMin;
public float absoluteMax;

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
        timeBtwSpawn = startTimeBtwSpawn;

        j = Moon.j;

        if (minimumSpawnTime > absoluteMin & maximumSpawnTime > absoluteMax){
            minimumSpawnTime = minimumSpawnTime - j * 1.5f;
            maximumSpawnTime = maximumSpawnTime - j * 1.5f;
        }

        if (minimumSpawnTime < absoluteMin){
             minimumSpawnTime = absoluteMin;
        } 
        
        if(maximumSpawnTime < absoluteMax) {
            maximumSpawnTime = absoluteMax;
        }

    }   else {
            timeBtwSpawn -= Time.deltaTime;
        }
}

}
