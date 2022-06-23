using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    AudioSource audioSource;
    public AudioClip endClip;
    public AudioClip obstaclClip;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManagerScript>().EndGame();
            audioSource.PlayOneShot(endClip, 0.5f);
        }
    }
    void OnTriggerEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "obstacle") 
        {
            audioSource.PlayOneShot(obstaclClip, 0.5f);
        }
    }
}
