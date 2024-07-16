using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject projectile;
    public Transform firePoint;
    ParticleSystem ps;
    public float projForce = 20f;

    public void Shoot(Transform target) {
        GameObject proj = Instantiate(projectile, firePoint.position, Quaternion.identity);
        ps = proj.GetComponent<ParticleSystem>();
        ps.Play();
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Vector3 vec = new Vector3(0f, 0f, angle);
        proj.transform.Rotate(vec);
        proj.GetComponent<Rigidbody2D>().velocity = direction * projForce;
    }
}
