using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : Movement
{
    private LevelManager levelmanager;

    [HideInInspector]
    public bool gameFinished=false;

    public GameObject SpinTheWheel;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Awake()
    {
        levelmanager = FindObjectOfType<LevelManager>();
    }

    private void FixedUpdate()
    {
        if (gameFinished == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                levelmanager.StartTheGame();
                Move(Vector3.forward);
                SpinTheWheel.transform.Rotate(0, 10f, 0.0f);

            }

            if (Input.GetMouseButtonUp(0))
            {
                Move(Vector3.zero);
                SpinTheWheel.transform.Rotate(0, 0, 0);
            }
               
        }

        else
        {
            Move(Vector3.forward);
        }
       
    }
   
}
