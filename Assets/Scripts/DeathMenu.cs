using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public GameManager gm;
    public Text wavesSurvived;
    public Text maxWaves;

    private void Start() {
        wavesSurvived.text = "SURVIVED " + (gm.wave - 1).ToString() + " WAVES";
        maxWaves.text = "HIGHEST WAVE SURVIVED WAS " + gm.maxWave;
    }

    private void Update() {
        Cursor.visible = true;
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
