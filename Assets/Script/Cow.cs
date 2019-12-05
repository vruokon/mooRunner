using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Cow : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    float moveSpeed = 1.5f;

    public GameObject cowDies;

    private Renderer rend;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    public int health = 1;

    //public string jumpSoundName;
    //public string deathSoundName;
    //cache
    private AudioManager audioManager;
    bool cowAlive = true;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        rend = GetComponent<Renderer>();

        //caching
        audioManager = AudioManager.instance;
        if (audioManager == null)
            Debug.LogError("No AudioManager found in scene");
    }

    void Update()
    {
        rb.MoveRotation(straightenCow(rb.position.x, rb.position.y));

        if (health <= 0 && cowAlive)
        {
            cowAlive = false;
            moveSpeed = 0f;
            health = 1;
            audioManager.PlaySound("Death");

            var myobject = Instantiate(cowDies, transform.position, Quaternion.identity);
            rend.enabled = false;

            //SceneManager.LoadScene("GameOver"); 
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) //Hyppää vain jos koskettaa maata
        {
            float jumpHeight = 6.0f;
            rb.velocity = Vector2.up * jumpHeight;
            audioManager.PlaySound("Jump");
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    // Siirrytään GameOver-ruutuun, mikäli lehmä on kameran ulkopuolella
    void OnBecameInvisible()
    {
        StartCoroutine(Wait());
    }

    //Tarkastetaan että lehmä koskettaa platformia
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        // Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    float straightenCow(float x, float y)
    {
        float moonX = 0.0f;
        float moonY = -6.0f;
        double doubMoonX = (double)moonX;
        double doubMoonY = (double)moonY;
        double doubX = (double)x;
        double doubY = (double)y;
        double deltaX = doubX - doubMoonX;
        double deltaY = doubY - doubMoonY;
        double rad = Math.Atan2(deltaY, deltaX);

        double angle = rad * (180 / Math.PI);
        angle -= 90;

        return (float)angle;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }


}