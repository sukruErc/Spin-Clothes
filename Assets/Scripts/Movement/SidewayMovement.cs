using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewayMovement : Movement
{
    [SerializeField] private MouseInput mouseInput;

    [SerializeField] private float minLimitAmount;
    [SerializeField] private float maxLimitAmount;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minLimitAmount, maxLimitAmount), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Move(new Vector3(mouseInput.MoveFactorX, 0f, 0f));
    }
}
