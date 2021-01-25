using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal PlayerController player;

    public LayerMask zombiesLayer;
    public LayerMask groundLayer;

    public List<uint> accessibleRooms;

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

    private void Start()
    {
        accessibleRooms = new List<uint>();
        accessibleRooms.Add(1);
    }

    public void UpdateAccessibleRooms(Door door)
    {
        if (!accessibleRooms.Contains(door.roomIdA))
            accessibleRooms.Add(door.roomIdA);

        if (!accessibleRooms.Contains(door.roomIdB))
            accessibleRooms.Add(door.roomIdB);
    }

}
