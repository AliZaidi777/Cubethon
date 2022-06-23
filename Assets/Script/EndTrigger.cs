using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public GameManagerScript gameManager;
    AudioSource audioSource;
    public AudioClip lvlCmolt;
    public Text levelnum;
    int s = 0;
    void Start()
    {
        PlayerPrefs.GetInt("lvlnum", 0);
        levelnum.text = PlayerPrefs.GetInt("lvlnum").ToString();
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {

        PlayerPrefs.SetInt("lvlnum", PlayerPrefs.GetInt("lvlnum") + 1);
        levelnum.text = PlayerPrefs.GetInt("lvlnum").ToString();
        gameManager.CompleteLevel();
        audioSource.PlayOneShot(lvlCmolt, 0.5f);
        s = 1;
    }
}
