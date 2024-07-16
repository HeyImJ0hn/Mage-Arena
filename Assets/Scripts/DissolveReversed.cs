using UnityEngine;

public class DissolveReversed : MonoBehaviour {
    Material material;

    [HideInInspector]
    public bool isDissolving = false;
    public bool dissolved = false;
    float fade = 1f;

    void Start() {
        material = GetComponent<SpriteRenderer>().material;
        //isDissolving = true;
    }

    void Update() {
        if (isDissolving) {
            fade -= Time.deltaTime;
            if (fade >= 0f) {
                fade = 0f;
                isDissolving = false;
                dissolved = true;
            }
            material.SetFloat("_Fade", fade);
        }
    }
}
