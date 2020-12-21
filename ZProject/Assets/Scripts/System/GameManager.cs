using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal PlayerController player;

    public LayerMask zombiesLayer;
    public LayerMask groundLayer;

    public GameObject ZObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = gameObject.GetComponent<GameManager>();
            return;
        }

        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ZObj.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    player.stats.armor.AddModifier(10);
        //}
    }


}
