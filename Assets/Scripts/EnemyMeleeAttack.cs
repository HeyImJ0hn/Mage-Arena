using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float range = 1f;
    public Transform playerTransform;
    Player player;
    public Enemy enemyScript;
    Dissolve dissolve;

    public float attackRate = 1f;
    public float timeToAttack = 1f;

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = playerTransform.GetComponent<Player>();
        dissolve = enemyScript.GetComponent<Dissolve>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        if (dissolve.dissolved && dist < range) {
            if (Time.time > timeToAttack) {
                player.TakeDamage(enemyScript.attackDmg);
                timeToAttack = Time.time + attackRate;
            }
        }
    }
}
