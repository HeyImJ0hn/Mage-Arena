using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 cameraOffset;

    GameManager gm;
    GameObject arena;

    bool move = false;

    private void Awake() {
        gm = FindObjectOfType<GameManager>();
        arena = GameObject.FindGameObjectWithTag("Arena");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.arena) {
            move = true;
        }
    }

    private void LateUpdate() {
        if (move)
            transform.position = arena.transform.position + cameraOffset;
    }
}
