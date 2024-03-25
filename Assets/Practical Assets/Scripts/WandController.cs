using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{
    public float maxXRotation = 75.0f;
    public float maxYRotation = 45.0f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        float xRotation = Input.mousePosition.x / Screen.width * maxXRotation - maxXRotation / 2.0f;
        float yRotation = (1.0f - Input.mousePosition.y / Screen.height) * maxYRotation;
        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
    }
}
