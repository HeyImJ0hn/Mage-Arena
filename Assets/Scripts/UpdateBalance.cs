using UnityEngine;
using UnityEngine.UI;

public class UpdateBalance : MonoBehaviour
{
    GameManager gm;
    public Text balance;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        balance.text = gm.balance.ToString();
    }
}
