using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject controls;
    public GameObject credits;

    public void Play()
    {
        SceneManager.LoadScene("World");
    }

    public void Controls()
    {
        controls.SetActive(true);
        main.SetActive(false);
    }

    public void Credits()
    {
        credits.SetActive(true);
        main.SetActive(false);
    }

    public void Back()
    {
        controls.SetActive(false);
        credits.SetActive(false);
        main.SetActive(true);
    }

    public void EndBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
