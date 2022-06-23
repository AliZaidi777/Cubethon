using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    // YourGameObject.GetComponent(YourScript).enabled = false
    public GameObject player;
    public GameObject button;
    public GameObject Setting;
    public GameObject level;
    public GameObject start;
    public GameObject swipeBtn;
    public GameObject touchBtn;
    public GameObject Btn;
    public GameObject soundOn;
    public GameObject soundOf;
    public Color selectedColor;
    public Color deSelectedColor;
    public GameObject mainCamera;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = mainCamera.GetComponent<AudioSource>();
      
        PlayerPrefs.GetInt("a", 0);
        if (PlayerPrefs.GetInt("a") == 0 || PlayerPrefs.GetInt("a") == 1)
        {
            Btn.GetComponent<Image>().color = selectedColor;
            swipeBtn.GetComponent<Image>().color = deSelectedColor;
            touchBtn.GetComponent<Image>().color = deSelectedColor;
        }
        if (PlayerPrefs.GetInt("a") == 2)
        {

            Btn.GetComponent<Image>().color = deSelectedColor;
            swipeBtn.GetComponent<Image>().color = selectedColor;
            touchBtn.GetComponent<Image>().color = deSelectedColor;
        }
        if (PlayerPrefs.GetInt("a") == 3)
        {
            Btn.GetComponent<Image>().color = deSelectedColor;
            swipeBtn.GetComponent<Image>().color = deSelectedColor;
            touchBtn.GetComponent<Image>().color = selectedColor;
        }
        if (PlayerPrefs.GetInt("s") == 4)
        {
            soundOn.GetComponent<Image>().color = selectedColor;
            soundOf.GetComponent<Image>().color = deSelectedColor;
            audioSource.enabled = true;
        }
        if(PlayerPrefs.GetInt("s") == 5)
        {
            soundOf.GetComponent<Image>().color = selectedColor;
            soundOn.GetComponent<Image>().color = deSelectedColor;
            audioSource.enabled = false;
        }
    }

    public void Button()
    {
        PlayerPrefs.SetInt("a", 1);
        Debug.Log("btn");
        Btn.GetComponent<Image>().color = selectedColor;
        swipeBtn.GetComponent<Image>().color = deSelectedColor;
        touchBtn.GetComponent<Image>().color = deSelectedColor;
    }
    public void Swipe()
    {
        Debug.Log("swip");
        PlayerPrefs.SetInt("a", 2);
        Btn.GetComponent<Image>().color = deSelectedColor;
        swipeBtn.GetComponent<Image>().color = selectedColor;
        touchBtn.GetComponent<Image>().color = deSelectedColor;
    }
    public void Touch()
    {
        Debug.Log("touch");
        PlayerPrefs.SetInt("a", 3);
        Btn.GetComponent<Image>().color = deSelectedColor;
        swipeBtn.GetComponent<Image>().color = deSelectedColor;
        touchBtn.GetComponent<Image>().color = selectedColor;
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("s", 4);
        soundOn.GetComponent<Image>().color = selectedColor;
        soundOf.GetComponent<Image>().color = deSelectedColor;
        audioSource.enabled = true;
    }
    public void SoundOff()
    {
        PlayerPrefs.SetInt("s", 5);
        soundOf.GetComponent<Image>().color = selectedColor;
        soundOn.GetComponent<Image>().color = deSelectedColor;
        audioSource.enabled = false;
    }
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("a") == 0 || PlayerPrefs.GetInt("a") == 1)
        {
            button.SetActive(true);
            player.GetComponent<MovementWithButton>().enabled = true;
            player.GetComponent<MoveWithMouse>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
         
        }
        if (PlayerPrefs.GetInt("a") == 2)
        {
            button.SetActive(false);
            player.GetComponent<MovementWithButton>().enabled = false;
            player.GetComponent<MoveWithMouse>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
          
        }
        if (PlayerPrefs.GetInt("a") == 3)
        {
            button.SetActive(false);
            player.GetComponent<MovementWithButton>().enabled = false;
            player.GetComponent<MoveWithMouse>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
          
        }
        start.SetActive(false);
        level.SetActive(true);
        Setting.SetActive(false);
    }
    public void Settings()
    {
        start.SetActive(false);
        level.SetActive(false);
        Setting.SetActive(true);
    }
    public void Back()
    {
        Setting.SetActive(false);
        level.SetActive(false);
        start.SetActive(true);
    }
}
