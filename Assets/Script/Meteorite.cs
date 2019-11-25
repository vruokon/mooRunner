using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour {

    public int damage = 1;
    public float speed = 5f;

    private Transform target;
    private Vector3 movementVector = Vector3.zero;
      
    void Start(){
        target = GameObject.FindWithTag("Cow").transform;
        movementVector = (target.position - transform.position).normalized;      
    }

    void Update(){  
        float step = speed * Time.deltaTime;    
        transform.position += movementVector * step;    
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);

        if (other.CompareTag("Cow")) {
            //Pelaaja ottaa vahinkoa.
            other.GetComponent<Cow>().health -= damage;
    
        }
    }

}
