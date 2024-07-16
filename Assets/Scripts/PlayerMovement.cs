using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    AudioManager am;

    public float moveSpeed = 5f;
    public float dashForce = 2f;
    public float dashCooldown = 2f;
    private bool dash = false;
    private bool canDash = true;

    public ParticleSystem dashParticles;

    public Rigidbody2D rb;

    private Vector2 movement;

    private bool facingRight = true;

    public Camera mainCam;

    public DashBarScript dashBar;

    float timeAt;

    SpriteRenderer sr;
    public Transform moveLight;

    Player player;

    private void Start() {
        am = FindObjectOfType<AudioManager>();
        dashBar.SetMaxDash(dashCooldown);
        sr = GetComponent<SpriteRenderer>();
        moveLight = transform.GetChild(1);
        player = GetComponent<Player>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) {
            player.god = true;
            Instantiate(dashParticles, transform.position, Quaternion.identity);
            am.Play("Dash");
            dash = true;
            canDash = false;
            StartCoroutine(DashCooldown());
            dashBar.SetDashValue(0);
            timeAt = Time.time;
        }

        if (!canDash) {
            dashBar.SetDashValue(Time.time - timeAt);
        }

        // using mousePosition and player's transform (on orthographic camera view)
        Vector3 delta = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (delta.x >= 0 && !facingRight) { // mouse is on right side of player
            sr.flipX = false;
            moveLight.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        } else if (delta.x < 0 && facingRight) { // mouse is on left side
            sr.flipX = true;
            moveLight.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (dash) {
            rb.MovePosition(rb.position + movement * moveSpeed * dashForce * Time.fixedDeltaTime);
            dash = false;
        }
    }

    IEnumerator DashCooldown() {
        player.god = false;
        yield return new WaitForSeconds(dashCooldown);
        dashBar.SetDashValue(dashCooldown);
        canDash = true;
    }
}
