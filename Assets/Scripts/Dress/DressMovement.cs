using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DressMovement : MonoBehaviour
{
    [SerializeField] private GameObject destroyedDress;      
    
    public Transform target;

    private Vector3 targetDress;

    [HideInInspector]
    public bool findSlot;

    public bool moveDress = false;

    private Vector3 velocity = Vector3.zero;
    
    private BoxCollider boxCollider;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        findSlot = true;
    }

    void Update()
    {

        if (findSlot==false)
        {

            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, 0f);
        }

        if (moveDress == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetDress, ref velocity, 1f);
        }
               
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scissors")
        {
            other.GetComponent<BoxCollider>().enabled = false;
            target.GetComponent<DressSlotAvailable>().slotEmpty = true;          
            Destroy(gameObject);
        }
        
        if(other.gameObject.tag == "DressToSlot")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            targetDress = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            StartCoroutine(MoveObject());                     
        }
    }
    IEnumerator MoveObject()
    {
        yield return new WaitForSeconds(0.1f);
        moveDress = true;
    }
}
