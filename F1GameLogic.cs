using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F1GameLogic : MonoBehaviour
{

    [SerializeField] List<GameObject> f1List;
    float timeAfterSpawn = 1.8f;
    float timeTillNextLevel = 5f;
    float movingSpeed = 2f;
    [SerializeField]TextMeshProUGUI text;
    int timesToFlashText = 3;
    F1SoundManager soundManager;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(SpawnRacecars());
        soundManager = FindObjectOfType<F1SoundManager>();
       
    }
    void Update()
    {
        if (timeTillNextLevel <= 0)
        {
            StopAllCoroutines();
            StartCoroutine(WaitForLevelToEnd());
            timesToFlashText = 3;
            soundManager.PlayPowerUp();
            StartCoroutine(FlashingText());
            TimeTillNextLevel();
            movingSpeed += 1.2f;
            //TODO: SHOW THAT NEW LEVEL HAS BEEN ACHIEVED
        }
        timeTillNextLevel -= Time.deltaTime;

    }
    IEnumerator WaitForLevelToEnd()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnRacecars());
    }


    IEnumerator FlashingText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(0.6f);
        text.enabled = false;
        yield return new WaitForSeconds(0.4f);
        timesToFlashText--;
        if (timesToFlashText > 0)
        {
            StartCoroutine(FlashingText());
        }
    }

    IEnumerator SpawnRacecars()
    {
        GameObject formulas = Instantiate(f1List[UnityEngine.Random.Range(0, f1List.Count - 1)], transform.position, Quaternion.identity)as GameObject;
        formulas.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -movingSpeed);
        yield return new WaitForSeconds(timeAfterSpawn);
        StartCoroutine(SpawnRacecars());
    }

    private void TimeTillNextLevel()
    {
        timeTillNextLevel = 10f;
    }
}
