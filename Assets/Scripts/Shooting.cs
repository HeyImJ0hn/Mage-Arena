using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject fireProj;
    public GameObject iceProj;
    public GameObject earthProj;

    private ParticleSystem ps;

    public GameObject mainCam;

    Player player;

    public float projForce = 20f;

    public float timeToFire = 0.1f;
    public float fireRate = 1f;

    AudioManager am;
    GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        player = gameObject.GetComponent<Player>();
        am = FindObjectOfType<AudioManager>();
    }

    private void Update() {
        if (Input.GetButton("Fire1")) {
            if (Time.time >= timeToFire) {
                Shoot();
                timeToFire = Time.time + fireRate;
            }
        }        
    }

    void Shoot() {
        am.Play("Shooting");
        GameObject proj;
        switch (player.spells[player.activeSpell]) {
            case "fire":
                fireRate = 1.1f;
                proj = Instantiate(fireProj, firePoint.position, Quaternion.identity);
                break;
            case "ice":
                fireRate = .8f;
                proj = Instantiate(iceProj, firePoint.position, Quaternion.identity);
                break;
            case "earth":
                fireRate = .4f;
                proj = Instantiate(earthProj, firePoint.position, Quaternion.identity);
                break;
            default:
                fireRate = .8f;
                proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                break;
        }
        ps = proj.GetComponent<ParticleSystem>();
        ps.Play();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 firepointPos = firePoint.position;
        Vector2 direction = (mousePos - firepointPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Vector3 vec = new Vector3(0f, 0f, angle);
        proj.transform.Rotate(vec);
        proj.GetComponent<Rigidbody2D>().velocity = direction * projForce;
    }
}
