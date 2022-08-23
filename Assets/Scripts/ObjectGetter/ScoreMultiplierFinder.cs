using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreMultiplierFinder : MonoBehaviour
{
    private static ScoreMultiplierFinder instance;

    public List<GameObject> checkpoints;
    public IReadOnlyList<GameObject> Checkpoints => checkpoints;

    public static ScoreMultiplierFinder Singleton
    {
        get
        {
            if (instance) return instance;

            instance = FindObjectOfType<ScoreMultiplierFinder>();

            if (instance) return instance;

            instance = new GameObject(nameof(ScoreMultiplierFinder)).AddComponent<ScoreMultiplierFinder>();

            return instance;
        }
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").OrderBy(waypoint => waypoint.name).ToList();
    }

}
