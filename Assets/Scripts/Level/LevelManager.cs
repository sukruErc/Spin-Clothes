using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject startingImage;
    [SerializeField] private GameObject levelFailedScreen;
    [SerializeField] private GameObject levelCompletedScreen;

    int currentIndex;

    /*------------------------------------------------------------------------------------------------------------------*/

    private void Awake()
    {
        startingImage.SetActive(true);
        levelFailedScreen.SetActive(false);
        levelCompletedScreen.SetActive(false);
    }

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    public void LevelFailedScreen()
    {
        levelFailedScreen.SetActive(true);
    }

    public void LevelCompletedScreen()
    {
        levelCompletedScreen.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex+1);
    }

    /*------------------------------------------------------------------------------------------------------------------*/

    #region Button Inputs
    public void RestartScene()
    {
        SceneManager.LoadScene(currentIndex);
    }

    public void StartTheGame()
    {
        startingImage.SetActive(false);
    }
    #endregion

}
