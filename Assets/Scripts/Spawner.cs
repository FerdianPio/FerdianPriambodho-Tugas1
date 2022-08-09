using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy, civilian;
    public int enemyPerWave, civilPerWave;
    public float timeToNextSpawn, timeToNextWave;
    private bool canSpawn;

    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnZombie(enemyPerWave));
            StartCoroutine(SpawnCivil(civilPerWave));
        }
    }

    public IEnumerator SpawnZombie(int enemyPerWave)
    {
        for (int i = 0; i < enemyPerWave; i++)
        {
            canSpawn = false;
            GameObject enemyInstance = Instantiate(enemy);
            enemyInstance.transform.localPosition = new Vector3((float)Random.Range(-8,8),transform.localPosition.y,0);
            yield return new WaitForSeconds(timeToNextSpawn);
        }
        yield return new WaitForSeconds(timeToNextWave);
        GameObject.Find("GameSetting").GetComponent<GameSetting>().wave += 1;
        StartCoroutine(SpawnZombie(enemyPerWave));
    }

    public IEnumerator SpawnCivil(int civilOnWave)
    {
        for(int i = 0; i < civilOnWave; i++)
        {
            GameObject civilInstance = Instantiate(civilian);
            civilInstance.transform.localPosition = new Vector3((float)Random.Range(-8, 8), transform.localPosition.y, 0);
            yield return new WaitForSeconds((float)Random.Range(2, 5));
        }
        yield return new WaitForSeconds(timeToNextWave);
        StartCoroutine(SpawnCivil(civilOnWave));
    }

}
