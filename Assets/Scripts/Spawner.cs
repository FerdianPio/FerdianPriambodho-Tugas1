using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy, civilian, minX, maxX;
    public RuntimeAnimatorController[] zombies;
    public Vector2 enemyPerWave, civilPerWave;
    public float timeToNextSpawn, timeToNextWave;
    private bool canSpawn;

    void Start()
    {
        canSpawn = true;
        Debug.Log(maxX.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnZombie(Random.Range((int)enemyPerWave.x,(int)enemyPerWave.y)));
            //StartCoroutine(SpawnCivil(Random.Range((int)civilPerWave.x, (int)civilPerWave.y)));
        }
    }

    public IEnumerator SpawnZombie(int enemyPerWave)
    {
        StartCoroutine(SpawnCivil(Random.Range((int)civilPerWave.x, (int)civilPerWave.y)));
        for (int i = 0; i < enemyPerWave; i++)
        {
            canSpawn = false;
            GameObject enemyInstance = Instantiate(enemy);
            enemy.gameObject.GetComponent<Animator>().runtimeAnimatorController = zombies[Random.Range(0, zombies.Length)];
            enemyInstance.transform.position = new Vector3(Random.Range(minX.transform.position.x, maxX.transform.position.x),transform.localPosition.y,0);
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
            civilInstance.transform.position = new Vector3(Random.Range(minX.transform.position.x, maxX.transform.position.x), transform.localPosition.y, 0);
            yield return new WaitForSeconds((float)Random.Range(2, 5));
        }
        yield return new WaitForSeconds(timeToNextWave);
        //StartCoroutine(SpawnCivil(civilOnWave));
    }

}
