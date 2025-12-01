using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    public float trailSpeed = 20f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 cursorOffset = new Vector3(0.25f, -0.25f, 0f);
        targetPos += cursorOffset;

        transform.position = Vector3.Lerp(transform.position, targetPos, trailSpeed * Time.deltaTime);
    }
}