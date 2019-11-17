using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class F1LoadScenes : MonoBehaviour
{
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("F1GameScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("F1MainMenu");
    }
    public void Quit()
    {
        FindObjectOfType<F1SoundManager>().KillMusic();
        SceneManager.LoadScene("3dScena");
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("F1GameOver");
    }
}
