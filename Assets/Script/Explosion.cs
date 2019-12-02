using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Cow")) {
            //Pelaaja ottaa vahinkoa.
            other.GetComponent<Cow>().health -= damage;
    
        }
    }
}
