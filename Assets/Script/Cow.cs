using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Cow : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    float moveSpeed = 3;

   private Rigidbody2D rb;
   private BoxCollider2D boxCollider2d;
   public int health = 3;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {   
        rb.MoveRotation(straightenCow(rb.position.x, rb.position.y));
        
        if (health <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) //Hyppää vain jos koskettaa maata
        {
            float jumpHeight = 6f;
            rb.velocity = Vector2.up * jumpHeight;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

// Siirrytään GameOver-ruutuun, mikäli lehmä on kameran ulkopuolella
    void OnBecameInvisible() {
        SceneManager.LoadScene("GameOver"); 
    }

//Tarkastetaan että lehmä koskettaa platformia
    private bool IsGrounded() {
     RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
   // Debug.Log(raycastHit2d.collider);
    return raycastHit2d.collider != null;
    }

    float straightenCow(float x, float y){
        float moonX = 0.0f;
        float moonY = -6.0f;
        decimal decMoonX = new decimal(moonX);
        decimal decMoonY = new decimal(moonY);
        double doubMoonX = (double)decMoonX;
        double doubMoonY = (double)decMoonY;
        decimal X = new decimal(x);
        decimal Y = new decimal(y);
        double doubX = (double)X;
        double doubY = (double)Y;
        double deltaX = doubX - doubMoonX;
        double deltaY = doubY - doubMoonY;
        double rad = Math.Atan2(deltaY, deltaX);

        double angle = rad * (180/Math.PI);
        angle  -=90;

        return (float)angle;
    }
}