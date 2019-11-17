using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    
    public void LoadGameOver()
    {
        SceneManager.LoadScene("SSGameOver");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SSGameScene");
        Player.getPlayer.health = 200;
        FindObjectOfType<ShowUIStats>().ResetScores();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("SSStartMenu");
    }
    public void Quit()
    {
        FindObjectOfType<ShowUIStats>().ResetScores();
        FindObjectOfType<MusicPlayer>().KillMusic();
        SceneManager.LoadScene("3dScena");
        //Cursor.lockState = CursorLockMode.Locked;
        
    }
}
