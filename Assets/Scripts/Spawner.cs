using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject []zombie, civilian;
    public RuntimeAnimatorController[] zombies;
    public Vector2 enemyPerWave, civilPerWave;
    public float timeToNextSpawn, timeToNextWave;
    private bool canSpawn;

    void Start()
    {
        canSpawn = true;
        //Debug.Log(Camera.main.orthographicSize * Camera.main.aspect);
    }

    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnZombie(Random.Range((int)enemyPerWave.x,(int)enemyPerWave.y)));
        }
    }

    public IEnumerator SpawnZombie(int enemyPerWave)
    {
        StartCoroutine(SpawnCivil(Random.Range((int)civilPerWave.x, (int)civilPerWave.y)));
        for (int i = 0; i < enemyPerWave; i++)
        {
            canSpawn = false;
            GameObject enemyInstance = Instantiate(zombie[Random.Range(0, zombie.Length)]);
            enemyInstance.gameObject.GetComponent<Animator>().runtimeAnimatorController = zombies[Random.Range(0, zombies.Length)];
            enemyInstance.transform.position = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect),transform.localPosition.y,0);
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
            GameObject civilInstance = Instantiate(civilian[0]);
            civilInstance.transform.position = new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), transform.localPosition.y, 0);
            yield return new WaitForSeconds((float)Random.Range(2, 5));
        }
        yield return new WaitForSeconds(timeToNextWave);
    }

}
