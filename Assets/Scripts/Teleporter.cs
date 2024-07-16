using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    public Transform targetLocation;
    public Transform player;
    private Transform mainCam;
    public GameObject arena;
    public GameManager gm;
    private SpriteRenderer sr;
    private Sprite defaultSprite;
    public Sprite selectedSprite;

    public Text tooltip;

    public GameObject gameUI;

    private float waitTime = 0f;
    private float pressedAt;

    private bool teleport = false;

    private void Start() {
        mainCam = FindObjectOfType<Camera>().transform;
        sr = GetComponent<SpriteRenderer>();
        defaultSprite = sr.sprite;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 1) {
            sr.sprite = selectedSprite;
            tooltip.enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && !teleport) {
                teleport = true;
                pressedAt = Time.time;
            }
        } else {
            tooltip.enabled = false;
            sr.sprite = defaultSprite;
        }
        if (teleport) {
            if (pressedAt + waitTime <= Time.time) {
                player.position = targetLocation.position;
                gameUI.SetActive(true);
                gm.arena = true;
                teleport = false;
            }
        }
    }

    private void LateUpdate() {
        if (teleport) {
            mainCam.position = targetLocation.position;
        }
    }
}
