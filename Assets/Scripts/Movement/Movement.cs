using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SurfaceSlider))]
public abstract class Movement : MonoBehaviour
{
    [SerializeField] public float speed;

    private Rigidbody _rigidbody;

    private SurfaceSlider surfaceSlider;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        surfaceSlider = GetComponent<SurfaceSlider>();
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

}
