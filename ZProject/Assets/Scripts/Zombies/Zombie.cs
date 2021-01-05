using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Stat maxHealth;          // Maximum amount of health
    public int rewardAmount;
    [SerializeField] Renderer renderer;
    [SerializeField] Color damaged66Color;
    [SerializeField] Color damaged33Color;


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

    public void TakeHit(int damages)
    {
        CurrentHealth -= damages;
        if (CurrentHealth <= 0)
        {
            PlayerGear gear = GameManager.Instance.player.GetComponent<PlayerGear>();
            if (gear)
            {
                gear.AddMoney(rewardAmount);
            }
            Destroy(gameObject);
        }
        else if (CurrentHealth <= 33)
        {
            ChangeColor(damaged33Color);
        }
        else if (CurrentHealth <= 66)
        {
            ChangeColor(damaged66Color);
        }
    }

    private void ChangeColor(Color color)
    {
        //Call SetColor using the shader property name "_Color" and setting the color to red
        renderer.material.SetColor("_Color", color);
    }
}
