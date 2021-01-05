using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    private List<Transform> spawners;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            Instantiate(zombiePrefab, spawners[i].position, Quaternion.identity);
        }
    }
}

//public class WaveSpawner : MonoBehaviour
//{
//    public static int EnemiesAlive = 0;
//    public Transform spawnPosition;
//    public Text waveCountdownText;
//    public float timeBetweenWaves = 5f;
//    public Wave[] waves;
//    public GameManager gameManager;

//    private float countdown = 2f;
//    private int waveIndex = 0;

//    private void Update()
//    {
//        if (EnemiesAlive > 0)
//        {
//            return;
//        }

//        if (waveIndex == waves.Length)
//        {
//            gameManager.WinLevel();
//            this.enabled = false;
//        }

//        if (countdown <= 0f)
//        {
//            StartCoroutine(SpawnWave());
//            countdown = timeBetweenWaves;
//            return;
//        }

//        countdown -= Time.deltaTime;
//        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

//        waveCountdownText.text = string.Format("{0:00.00}", countdown);
//    }

//    IEnumerator SpawnWave()
//    {
//        PlayerStats.Rounds++;
//        Wave wave = waves[waveIndex];
//        EnemiesAlive = wave.count;
//        for (int i = 0; i < wave.count; i++)
//        {
//            SpawnEnemy(wave.enemy);
//            yield return new WaitForSeconds(1f / wave.rate);
//        }
//        waveIndex++;

//    }

//    void SpawnEnemy(GameObject enemy)
//    {
//        GameObject GO = Instantiate(enemy, spawnPosition.position, spawnPosition.rotation);
//        GO.transform.parent = GameObject.Find("Enemies").transform;
//    }
//}
