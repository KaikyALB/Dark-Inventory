using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseBehavior : MonoBehaviour
{
    public Vector3 mousePos;
    void Start()
    {

    }
    void Update()
    {
        mousePos = transform.position;
    }
}
