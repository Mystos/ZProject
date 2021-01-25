using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    private Spawner[] spawners;

    public float delay = 10f;
    public float decreaseFactor = 0.95f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnZombie();
            if (delay > 1)
            {
                delay *= decreaseFactor;
            }
            timer = delay;
        }
    }

    public void SpawnZombie()
    {
        Spawner[] availableSpawners = spawners.Where(s => GameManager.Instance.accessibleRooms.Contains(s.roomId)).ToArray();
        int spawnerId = Random.Range(0, availableSpawners.Length);
        Instantiate(zombiePrefab, availableSpawners[spawnerId].transform.position, Quaternion.identity);
    }
}