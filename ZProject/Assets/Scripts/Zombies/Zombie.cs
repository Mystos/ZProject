using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    public Stat maxHealth;          // Maximum amount of health
    public int rewardAmount;
    [SerializeField] Renderer renderer;
    [SerializeField] Color damaged66Color;
    [SerializeField] Color damaged33Color;

    [Header("Attack")]
    public int damages = 20;
    public float attackRange;
    public Transform attackPoint;
    public float attackColldown = 2f;
    private float timer = 0f;
    private bool canAttack = false;

    public int CurrentHealth { get; protected set; }    // Current amount of health
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        CurrentHealth = maxHealth.baseValue;
    }

    // Update is called once per frame
    void Update() {

        if (canAttack == false) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0) {
            timer = attackColldown;
            canAttack = true;
        }

        agent.SetDestination(GameManager.Instance.player.transform.position);

        Collider[] cols = Physics.OverlapSphere(attackPoint.position, attackRange, GameManager.Instance.playerLayer);
        if (cols.Length > 0) {
            PlayerStats playerStats = cols[0].GetComponent<PlayerStats>();
            if (playerStats) {
                Attack(playerStats);
            }
        }
    }

    public void TakeHit(int damages) {

        CurrentHealth -= damages;

        if (CurrentHealth <= 0) {
            PlayerGear gear = GameManager.Instance.player.GetComponent<PlayerGear>();
            if (gear) {
                gear.AddMoney(rewardAmount);
            }

            Destroy(gameObject);
        }
        else if (CurrentHealth <= maxHealth.GetValue() * 0.33f) {
            ChangeColor(damaged33Color);
        }
        else if (CurrentHealth <= maxHealth.GetValue() * 0.66f) {
            ChangeColor(damaged66Color);
        }
    }

    public void Attack(PlayerStats player) {

        if (canAttack == true) {
            Debug.Log("Attack");
            player.TakeDamage(damages);
            canAttack = false;
        }
    }

    private void ChangeColor(Color color) {
        //Call SetColor using the shader property name "_Color" and setting the color to red
        renderer.material.SetColor("_Color", color);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
