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

    public void Quit()
    {
        ApplicationController.Instance.Quit();
    }
}
