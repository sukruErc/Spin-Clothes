using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCollector : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private CameraFollow360 mainCamera;

    public List<GameObject> Cells = new List<GameObject>();

    [Header("Objects")]
    public GameObject cellHolder;

    public GameObject dressHolder;

    LevelManager levelManager;

    GameObject player;
    
    [HideInInspector]
    public int _height;

    [HideInInspector]
    public int scoreMultiplier = 1;

    /*------------------------------------------------------------------------------------------------------------------*/

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        player.transform.position = new Vector3(transform.position.x, _height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -_height, 0);
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    public void DecreaseHeight()
    {
        _height--;
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableCell" && other.gameObject.GetComponent<CollectableCell>().GetCollected() == false)
        {
            mainCamera.DecreaseHeight();

            Cells.Add(other.gameObject);

            _height += 1;

            other.gameObject.GetComponent<CollectableCell>().Collected();
            other.gameObject.GetComponent<CollectableCell>().IndexValue(_height);
            other.gameObject.transform.parent = player.transform;
        }

        if (other.gameObject.tag == "Dress")
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                var CellSlot = Cells[i].GetComponent<Dresser>().dressTransform;

                for (int x = 0; x < CellSlot.Length; x++)
                {
                    if (CellSlot[x].GetComponent<DressSlotAvailable>().slotEmpty)
                    {
                        Transform newTransform = Cells[i].gameObject.GetComponent<Dresser>().dressTransform[x];
                        other.GetComponent<DressMovement>().target = newTransform;
                        newTransform.GetComponent<DressSlotAvailable>().slotEmpty = false;
                        other.GetComponent<DressMovement>().findSlot = false;

                        other.transform.parent = dressHolder.transform;
                        return;
                    }
                }
            }

        }

        if (other.gameObject.tag == "Obstacle")
        {
            if (_height == 0)
            {
                player.GetComponent<ForwardMovement>().enabled = false;
                player.GetComponent<SidewayMovement>().enabled = false;
                levelManager.LevelFailedScreen();
            }
        }

        if (other.gameObject.tag == "FinishLine")
        {
            StartCoroutine(AnimateRotationTowards(player.transform, Quaternion.identity, 1f));       

            DressMovement[] dress = FindObjectsOfType<DressMovement>();
            foreach (DressMovement a in dress)
            {
                a.GetComponent<BoxCollider>().enabled = false;
            }

            if (_height == 0)
            {
                player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
                player.GetComponent<SidewayMovement>().enabled = false;
                player.GetComponent<ForwardMovement>().gameFinished = true;
                StartCoroutine(moveDress());
            }

            if (_height >= 1)
            {
                player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
                player.GetComponent<SidewayMovement>().enabled = false;
                player.GetComponent<ForwardMovement>().gameFinished = true;
            }
        }

        if (other.gameObject.tag == "Checkpoint")
        {
            scoreMultiplier++;

            if (_height == 0)
            {          
                scoreMultiplier++;
                player.GetComponent<ForwardMovement>().enabled = false;
                player.transform.position = other.transform.position;
                StartCoroutine(moveDress());
            }
        }            
    }

    IEnumerator moveDress()
    {
        yield return new WaitForSeconds(0.5f);
        DressMovement[] dress = FindObjectsOfType<DressMovement>();
        foreach (DressMovement a in dress)
        {
            a.findSlot = true;
            a.GetComponent<BoxCollider>().enabled = true;
        }

        yield return new WaitForSeconds(2f);

        levelManager.LevelCompletedScreen();

    }

    private System.Collections.IEnumerator AnimateRotationTowards(Transform target, Quaternion rot, float dur)
    {
        float t = 0f;
        Quaternion start = target.rotation;
        while (t < dur)
        {
            target.rotation = Quaternion.Slerp(start, rot, t / dur);
            yield return null;
            t += Time.deltaTime;
        }
        target.rotation = rot;
    }

}
