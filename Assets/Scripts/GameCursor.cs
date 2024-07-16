using UnityEngine;

public class GameCursor : MonoBehaviour {
    public Texture2D cursorDot;



    private void Start() {
        Cursor.visible = false;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update() {
        Cursor.visible = false;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}