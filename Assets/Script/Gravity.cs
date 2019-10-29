using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float massOfMoon;
    public Transform centerOfMoon;
    public float G;

    float massOfplayer;
    float distance;
    float forceValue;
    Vector3 forceDirection;

    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        massOfplayer = rbody.mass;
        distance = Vector3.Distance(centerOfMoon.position, transform.position);
        forceValue =  G * (massOfMoon * massOfplayer) / (distance * distance);
        
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = centerOfMoon.position - transform.position;
        rbody.AddForce(forceValue * forceDirection);
    }
}
