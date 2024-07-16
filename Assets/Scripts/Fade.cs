using UnityEngine;

public class Fade : MonoBehaviour
{
    public float timeUntilFade = 5f;
    private float fade = 1f;
    private Material material;
    private float spawnTime;
    private bool fading = false;

    private void Start() {
        material = GetComponent<SpriteRenderer>().material;
        spawnTime = Time.time;
    }

    void Update()
    {
        if ((spawnTime + timeUntilFade <= Time.time && !fading) || fading) {
            fading = true;
            if (fade > 0) {
                fade -= Time.deltaTime;
                material.SetFloat("_Fade", fade);
            } else
                Destroy(gameObject);
        }
    }
}
