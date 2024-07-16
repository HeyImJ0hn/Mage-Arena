using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;

    private bool isDissolving = false;
    public bool dissolved = false;
    float fade = 0f;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        isDissolving = true;
    }

    void Update()
    {
        if (isDissolving) {
            fade += Time.deltaTime;
            
            if (fade >= 1f) {
                fade = 1f;
                isDissolving = false;
                dissolved = true;
            }
            material.SetFloat("_Fade", fade);
        }
    }
}
