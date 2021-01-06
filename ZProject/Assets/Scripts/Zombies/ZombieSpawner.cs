using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ZombieSpawner : MonoBehaviour
{
    public int roomId;
    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnZombie();
        }
    }

    public void SpawnZombie()
    {
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
    }
}
