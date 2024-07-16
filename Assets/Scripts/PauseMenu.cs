using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private GameObject player;
    PlayerMovement pm;
    Shooting shooting;

    private void Start() {
        player = FindObjectOfType<Player>().gameObject;
        pm = player.GetComponent<PlayerMovement>();
        shooting = player.GetComponent<Shooting>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pm.enabled = true;
        shooting.enabled = true;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pm.enabled = false;
        shooting.enabled = false;
    }

}
