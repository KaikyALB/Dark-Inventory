using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryWheel : MonoBehaviour
{
    public RectTransform[] items;
    RectTransform frontObject;
    Collider2D[] itemColliders; //Stores the colliders of every object on the items array

    public float radius = 200f; //Distance from the center
    public float rotationSpeed = 120f; //How fas the items move when scrolling
    public float horizontalSpread = 50f;
    public float highestY = float.MinValue; //Gets the minimum value of a float
    private float currentRotation;

    public int selectedIndex = 0;
   
    Vector3[] baseScale;
    Vector2[] basePos;
    void Start()
    {
        itemColliders = new Collider2D[items.Length];
        
        baseScale = new Vector3[items.Length];
        basePos = new Vector2[items.Length];
        for (int i = 0; i < items.Length;i++)
        {
            if (items[i].anchoredPosition.y > highestY) //This finds the object on the front of the wheel
            {
                highestY = items[i].anchoredPosition.y;
                frontObject = items[i];
                frontObject.GetComponent<Collider2D>().enabled = true;
            }//------------------------------------------------------------------------------------------
            itemColliders[i] = items[i].GetComponent<Collider2D>();
            baseScale[i] = items[i].localScale;
            basePos[i] = items[i].anchoredPosition;
        }
        ArrangeItems();
    }
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll > 0)
        {
            selectedIndex--;
            ArrangeItems();
        }
        else if (scroll < 0)
        {
            selectedIndex = (selectedIndex + items.Length) % items.Length;
            ArrangeItems();
        }
    }
    public void ArrangeItems()
    {
        float angleStep = 360f / items.Length; //checks the amount of items and angles them to be around the circle

        for(int i = 0; i < items.Length; i++)
        {
            int indexOffset = (i - selectedIndex + items.Length) % items.Length;

            float angle = indexOffset * angleStep * Mathf.Deg2Rad;

            float x = Mathf.Sin(angle) * horizontalSpread;
            float y = Mathf.Cos(angle) * radius;

            float scale = Mathf.Lerp(0.5f, 1f,(y + radius)/(2 * radius));

            basePos[i] = new Vector3(x, y, 0);
            items[i].localScale = baseScale[i] * scale;
        }
    }
}
