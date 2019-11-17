using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;
    int startingWave = 0;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        { 
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        waveConfig.GetPrefabNumber();
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                        waveConfig.GetWaypoints()[0].transform.position,
                        Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    
    private IEnumerator SpawnAllWaves()
    {
        //for(int waveIndex = 0; waveIndex < waveConfigs.Count; waveIndex++)
        //{
        //    var currentWave = waveConfigs[waveIndex];
        //    yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        //}
        foreach(WaveConfig wave in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(wave));
        }
    }
}
