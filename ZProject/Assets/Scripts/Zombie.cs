using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Stat maxHealth;          // Maximum amount of health
    public int CurrentHealth { get; protected set; }    // Current amount of health

    private NavMeshAgent agent;


    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameManager.Instance.player.transform.position);
    }
}
