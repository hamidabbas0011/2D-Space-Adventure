using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private GameObject asteroidContainer;
    private bool _stopSpawn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpsSpawnRoutine());
        StartCoroutine(AsteroidSpawnRoutine());
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    IEnumerator EnemySpawnRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 position = new Vector3(Random.Range(-12, 12), 10, 0);
            GameObject allEnemies = Instantiate(enemyPrefab, position, Quaternion.identity);
            allEnemies.transform.parent = enemyContainer.transform; //containing all enemies in 1 parent
            yield return new WaitForSeconds(Random.Range(2.0f,5.0f));
            //the above will store every enemy gameObject in one gameObject (container)
        }
    }

    IEnumerator AsteroidSpawnRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 position = new Vector3(Random.Range(-12, 12), 10, 0);
            GameObject allAsteroids = Instantiate(asteroidPrefab, position, Quaternion.identity);
            allAsteroids.transform.parent = asteroidContainer.transform; //containing all asteroids in 1 parent
            yield return new WaitForSeconds(Random.Range(4.0f, 10.0f));
        }
    }
    IEnumerator PowerUpsSpawnRoutine()
    {
        while (_stopSpawn ==false )
        {
            Vector3 position = new Vector3(Random.Range(-12, 12), 10, 0);
            int randomPowerUps = Random.Range(0,3);
            Instantiate(powerUps[randomPowerUps], position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6.0f,10.0f)); 
        }
    }

    public void StopSpawning()
    {
        _stopSpawn = true;
        Destroy(this.gameObject);
    }
}
