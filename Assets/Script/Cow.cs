using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (health <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) //Hyppää vain jos koskettaa maata
        {
            float jumpHeight = 5f;
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

//Tarkastetaan että lehmä koskettaa platformia
    private bool IsGrounded() {
     RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
   // Debug.Log(raycastHit2d.collider);
    return raycastHit2d.collider != null;
    }
}