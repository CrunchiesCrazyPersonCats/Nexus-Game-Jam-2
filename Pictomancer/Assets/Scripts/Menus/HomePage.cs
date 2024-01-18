using Pictomancer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
    }

    public void Home()
    {
        SceneManager.LoadScene(Constants.HOMEPAGE_SCENE);
    }

    public void Credits()
    {
        SceneManager.LoadScene(Constants.CREDITS_SCENE);
    }

    public void Quit()
    {
        ApplicationController.Instance.Quit();
    }
}
