using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{

public GameObject obstacle;

private float timeBtwSpawn;
private float startTimeBtwSpawn;
public float minimumSpawnTime;
public float maximumSpawnTime;


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
    }   else {
            timeBtwSpawn -= Time.deltaTime;
        }
}

}


