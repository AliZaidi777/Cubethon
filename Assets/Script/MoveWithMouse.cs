using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private float speed = 0.05f;
    private Touch touch;
    public Rigidbody rb;
     float forwardForce = 8000;
    AudioSource audioSource;
    public AudioClip endClip;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y, transform.position.z); 
            }
        }
        if (rb.position.y < -1f || rb.position.x > 8f || rb.position.x < -8f)
        {
            FindObjectOfType<GameManagerScript>().EndGame();
            audioSource.PlayOneShot(endClip, 0.5f);
        }
    }
}
