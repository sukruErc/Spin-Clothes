using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private float lastFrameMousePositionX;

    private float moveFactorX;
    public float MoveFactorX => moveFactorX;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameMousePositionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameMousePositionX;
            lastFrameMousePositionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
        }
    }

}
