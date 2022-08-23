using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    private Vector3 normal;

    /*------------------------------------------------------------------------------------------------------------------*/

    public Vector3 Project(Vector3 vector)
    {
        return Vector3.ProjectOnPlane(vector, normal);
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    private void OnCollisionEnter(Collision collision)
    {
        normal = collision.contacts[0].normal;
    }
}
