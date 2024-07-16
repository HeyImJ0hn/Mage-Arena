using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
    private static Tooltip instance;

    [SerializeField]
    private Camera uiCamera;

    private Text tooltipText;
    private Transform player;

    private Vector3 offset = new Vector3(0, 10, 0);

    private void Awake() {
        instance = this;
        tooltipText = GetComponent<Text>();
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition + offset, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(string tooltipString) {
        gameObject.SetActive(true);
        tooltipText.text = tooltipString;
    }

    private void HideTooltip() {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString) {
        instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltip_Static() {
        instance.HideTooltip();
    }

}
