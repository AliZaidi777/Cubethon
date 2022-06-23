using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithButton : MonoBehaviour
{
    public Rigidbody rb;
    float forwardForce = 7500f;
    private float sidemoveForce = 600f;
    AudioSource audioSource;
    public AudioClip endClip;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (rb.position.y < -1f || rb.position.x > 8f || rb.position.x < -8f)
        {
            FindObjectOfType<GameManagerScript>().EndGame();
            audioSource.PlayOneShot(endClip, 0.5f);
        }
    }
    public void LeftMove()
    {
        rb.AddForce(-sidemoveForce, 0, forwardForce * Time.deltaTime);
    }    public void RightMove()
    {
        rb.AddForce(sidemoveForce, 0, forwardForce * Time.deltaTime);
    }

}
