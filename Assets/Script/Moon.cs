using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(rotate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator rotate()
    {
        float i = 0;
        float j = 0.05f;
        while (true)
        {
            i += j;
            rb2D.MoveRotation((float)i);
            yield return new WaitForSeconds(.01f);
            j += 0.0005f;
        }
    }
}
