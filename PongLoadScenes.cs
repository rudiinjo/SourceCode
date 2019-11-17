using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PongLoadScenes : MonoBehaviour
{

    public void LoadPongGameScene()
    {
        SceneManager.LoadScene("PongMainScene");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("PongGameOver");
    }
    public void loadQuit()
    {
        SceneManager.LoadScene("3dScena");
    }
}
