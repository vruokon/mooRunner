using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avaruusAlus : MonoBehaviour
{
    float moveSpeed = 1.1f;
    private bool isMoving = true;
    private bool continueMoving = false;
    private bool isCreated = false;

    private Rigidbody2D alus;
    private AudioManager audioManager;
    private Transform target;
    private Vector3 targetPos;
    private GameObject myObject;
    public GameObject obstacle;


    void Start()
    {
        target = GameObject.FindWithTag("Cow").transform;

        //caching
        audioManager = AudioManager.instance;
        if (audioManager == null)
            Debug.LogError("No AudioManager found in scene");

        audioManager.PlaySound("Ufo");

    }

    // Update is called once per frame
    void Update()
    {

        float step = moveSpeed * Time.deltaTime;

        targetPos = transform.position;

        if (targetPos.x == target.position.x)
        {
            isMoving = false;
            StartCoroutine(Wait());
        }

        if (isMoving == true)
        {
            targetPos.x = target.transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

        if (continueMoving == true)
        {
            transform.position += Vector3.left * step;
        }


    }

    // Tuhoaa objektin, kun se on kadonnut kameran alueelta
    void OnBecameInvisible()
    {
        audioManager.MuteSound("Ufo");
        Destroy(gameObject);
    }

    // Odottaa pelaajan paikalla hetken aikaa
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        if (isCreated == false)
        {
            myObject = Instantiate(obstacle, transform.position, Quaternion.identity);
            isCreated = true;
            audioManager.PlaySound("Laser");
        }

        yield return new WaitForSeconds(3);
        Destroy(myObject);
        continueMoving = true;


    }

}
