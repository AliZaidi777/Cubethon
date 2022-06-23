using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    float forwardForce=  8000f;
    float sidemoveForce = 750;
    private float swipeRes = 50.0f;
    Vector2 touchPositiopn;
    AudioSource audioSource;
    public AudioClip endClip;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {
            touchPositiopn = Input.mousePosition;
          
        }
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPositiopn - (Vector2)Input.mousePosition;
            if(Mathf.Abs(deltaSwipe.x) > swipeRes)
            {
                if(deltaSwipe.x < 0)
                {
                    rb.AddForce(sidemoveForce, 0, forwardForce * Time.deltaTime);
                }
                else
                {
                    rb.AddForce(-sidemoveForce, 0, forwardForce * Time.deltaTime);
                }
            }
        }
        if (rb.position.y < -1f || rb.position.x > 8f || rb.position.x < -8f)
        {
            FindObjectOfType<GameManagerScript>().EndGame();
            audioSource.PlayOneShot(endClip, 0.5f);
        }
    }
}
