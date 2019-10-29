using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

public GameObject obstacle;
public GameObject parentObject;
public GameObject objectRotation;

private float timeBtwSpawn;
private float startTimeBtwSpawn;
public float decreaseTime;


 void Start() 
{ 
    startTimeBtwSpawn = Random.Range(7, 10);  
}


void Update()
{
    
    if (timeBtwSpawn <= 0) {
        var myObject = Instantiate(obstacle, transform.position, Quaternion.identity);
        myObject.transform.parent = parentObject.transform;
        myObject.transform.rotation = objectRotation.transform.rotation; 
        
        startTimeBtwSpawn = Random.Range(7, 10);
        Debug.Log(startTimeBtwSpawn);
        timeBtwSpawn = startTimeBtwSpawn;
    }   else {
            timeBtwSpawn -= Time.deltaTime;
        }
}

}
