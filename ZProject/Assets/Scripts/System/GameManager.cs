using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal PlayerController player;

    public LayerMask zombiesLayer;
    public LayerMask groundLayer;

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

        Cursor.visible = false;
    }

    private void Update()
    {

    }


}
