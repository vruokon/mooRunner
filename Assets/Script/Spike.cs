using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    public int damage = 1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cow")) {
            //Pelaaja ottaa vahinkoa.
            other.GetComponent<Cow>().health -= damage;
           Debug.Log(other.GetComponent<Cow>().health);
        }
    }

    // Tuhoaa objektin, kun se on kadonnut kameran alueelta
    void OnBecameInvisible() {
         Destroy(gameObject);
     }

}
