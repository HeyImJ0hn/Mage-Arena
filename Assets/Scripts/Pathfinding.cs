using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;
    public float stopDist = .8f;
    public bool move = true;
    SpriteRenderer sr;

    public bool ranged = false;

    public float timeToFire = 0.1f;
    public float fireRate = 1f;

    private Dissolve dissolve;

    EnemyShoot enemyShoot;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        dissolve = GetComponent<Dissolve>();
        if (ranged)
            enemyShoot = gameObject.GetComponent<EnemyShoot>();
    }
    
    void FixedUpdate()
    {
        if (dissolve.dissolved) {
            if (move) {
                if (Vector2.Distance(transform.position, target.position) > stopDist)
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                else { 
                    if (ranged) {
                        if (Time.time >= timeToFire) {
                            enemyShoot.Shoot(target);
                            timeToFire = Time.time + fireRate;
                        }
                    }
                }
                if (target.position.x > transform.position.x)
                    sr.flipX = false;
                else
                    sr.flipX = true;
            }
        }
    }
}
