
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    bool gameHasEnd = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    
    public void EndGame()
    {
        if(gameHasEnd == false)
        {
            gameHasEnd = true;
          
            Invoke("Restart", restartDelay);
        }  
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("lvlnum", 0);
    }
}
