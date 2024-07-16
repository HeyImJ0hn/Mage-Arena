using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    SpriteRenderer sr;
    Material matDefault;
    Material matWhite;

    AudioManager am;

    private void Start() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        matDefault = sr.material;
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        am = FindObjectOfType<AudioManager>();
    }

    public void Hit() {
        sr.material = matWhite;
        Invoke("ResetMat", .2f);
        am.Play("EnemyHit");
    }

    private void ResetMat() {
        sr.material = matDefault;
    }
}
