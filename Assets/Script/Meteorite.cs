using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour {

    public int damage = 1;
    public float speed = 5f;
    

    public GameObject explosion;
    private GameObject explode;

    private Transform target;
    private Vector3 movementVector = Vector3.zero;

    private AudioManager audioManager;
      
    void Start(){
        target = GameObject.FindWithTag("Cow").transform;
        movementVector = (target.position - transform.position).normalized;     
        
        //caching
        audioManager = AudioManager.instance;
        if( audioManager == null)
        Debug.LogError("No AudioManager found in scene"); 

          audioManager.PlaySound("Falling");
    }

    void Update(){        
        float step = speed * Time.deltaTime;    
        transform.position += movementVector * step;     
    }

    void OnTriggerEnter2D(Collider2D other){ 
        audioManager.PlaySound("Explosion");

        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
        
        if (other.CompareTag("Cow")) {
            //Pelaaja ottaa vahinkoa.
            other.GetComponent<Cow>().health -= damage;
    
        }
    }

}
