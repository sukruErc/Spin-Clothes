using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMace : MonoBehaviour
{
    [SerializeField] private float yspeed;
   
    void Update()
    {
        transform.Rotate(0, -yspeed , 0);
    }
}
