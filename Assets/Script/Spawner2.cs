using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{

public GameObject obstacle;

public float timeBtwSpawn;
public float minimumSpawnTime;
public float maximumSpawnTime;
public float absoluteMin;
public float absoluteMax;

private float startTimeBtwSpawn;
private float j;


 void Start() 
{ 
    startTimeBtwSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);  
}


void Update()
{
    
    if (timeBtwSpawn <= 0) {
        var myObject = Instantiate(obstacle, transform.position, Quaternion.identity);
        
        startTimeBtwSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        timeBtwSpawn = startTimeBtwSpawn;

        j = Moon.j;

        if (minimumSpawnTime > absoluteMin & maximumSpawnTime > absoluteMax){
            minimumSpawnTime = minimumSpawnTime - j;
            maximumSpawnTime = maximumSpawnTime - j;
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


