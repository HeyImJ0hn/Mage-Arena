using UnityEngine;
using UnityEngine.UI;

public class UpdateTextShadow : MonoBehaviour
{
    public Text wave;

    void Update()
    {
        transform.gameObject.GetComponent<Text>().text = wave.text;
    }
}
