using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avaruusAlus : MonoBehaviour
{
    float moveSpeed = 1.1f;
    private Rigidbody2D alus;
    private AudioManager audioManager;
    
    void Start()
    {
        alus = transform.GetComponent<Rigidbody2D>();
        alus.velocity = new Vector2(-moveSpeed, alus.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        alus.velocity = new Vector2(-moveSpeed, alus.velocity.y);  
        //audioManager.PlaySound("Ufo");
        
    }


    // Tuhoaa objektin, kun se on kadonnut kameran alueelta
    void OnBecameInvisible() {
         Destroy(gameObject);
    }

}
