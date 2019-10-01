using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float up;
    // Start is called before the first frame update
    void Start()
    {   //getcomponent like getElementById
        rb2D = GetComponent<Rigidbody2D>();
        //StartCoroutine(rotate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            rb2D.velocity = new Vector3(0.0f, up, 0.0f);
        }
    }
    IEnumerator rotate()
    {
        int i = 0;
        while (true)
        {
            i += 1;
            rb2D.MoveRotation((float)i);
            yield return new WaitForSeconds(.01f);
        }
    }
}