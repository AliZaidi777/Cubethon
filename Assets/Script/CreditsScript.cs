using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public void Quit()
    {
        PlayerPrefs.SetInt("lvlnum", 0);
        SceneManager.LoadScene("Level1");
    }
}
