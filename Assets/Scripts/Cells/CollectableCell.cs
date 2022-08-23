using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCell : MonoBehaviour   
{
    [SerializeField] private CameraFollow360 mainCamera;

    public CellCollector cellCollector;
   
    private bool collected = false;
    
    int index;

    /*------------------------------------------------------------------------------------------------------------------*/

    void Update()
    {
        if(transform.parent != null)
        {
            if (collected == true)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
        
            
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    public bool GetCollected()
    {
        return collected;
    }

    public void Collected()
    {
        collected = true;
    }

    public void IndexValue(int index)
    {
        this.index = index;
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Checkpoint")
        {
            mainCamera.IncreaseHeight();

            cellCollector.DecreaseHeight();

            transform.parent = null;

            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            cellCollector.Cells.RemoveAt(cellCollector.Cells.Count - 1);


           
        }
    }

}
