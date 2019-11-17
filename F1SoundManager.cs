using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1SoundManager : MonoBehaviour
{
    [SerializeField]AudioClip powerUp;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip addPoints;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }
    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);

    }
    public void PlayAddPoints()
    {
        AudioSource.PlayClipAtPoint(addPoints, Camera.main.transform.position) ;
    }
    public void KillMusic()
    {
        Destroy(gameObject);
    }
}
