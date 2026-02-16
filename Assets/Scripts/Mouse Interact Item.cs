using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInteractItem : MonoBehaviour
{
    public Sprite restImage;
    public Sprite highlightedImage;

    public Vector3 restImageSize;
    public Vector3 highlightedImageSize;

    [SerializeField]public RectTransform smallPanel;
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        
    }
    private void Update()
    {
        SpriteRenderer restImage = GetComponentInChildren<SpriteRenderer>();
        restImage.transform.localScale = restImageSize;

        SpriteRenderer highlightedImage = GetComponentInChildren<SpriteRenderer>();
        highlightedImage.transform.localScale = highlightedImageSize;
    }
    private void OnMouseOver()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = highlightedImage;
    }
    private void OnMouseExit()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = restImage;
    }
    private void OnMouseDown()
    {
        smallPanel.gameObject.SetActive(true);

        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                                                                Input.mousePosition, canvas.worldCamera,
                                                                 out localPoint);

        smallPanel.localPosition = localPoint;
    }
}
