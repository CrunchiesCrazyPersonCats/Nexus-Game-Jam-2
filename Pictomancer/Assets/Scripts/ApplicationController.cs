using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Pictomancer
{

    public class ApplicationController : MonoBehaviour
    {
        public enum GameCondition
        {
            Start,
            OnGoing,
            Won,
            Lost
        }

        public static ApplicationController Instance { get; private set; }
        public GameCondition gameCondition { get; private set; }

        void Awake()
        {
            if (Instance)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            // Application settings
            //Application.wantsToQuit += OnWantToQuit;
            SceneManager.activeSceneChanged += OnSwitchScene;
            Application.targetFrameRate = 120;
            DontDestroyOnLoad(gameObject);

            // Start
            gameCondition = GameCondition.Start;
            SceneManager.LoadScene(Constants.HOMEPAGE_SCENE);
        }

        #region ApplicationReactions
        //private bool OnWantToQuit()
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            //return true;
        }

        private void OnSwitchScene(Scene current, Scene next)
        {
            switch (current.name)
            {
                case Constants.HOMEPAGE_SCENE:
                    gameCondition = GameCondition.Start;
                    break;
                case Constants.GAME_SCENE:
                    gameCondition = GameCondition.OnGoing;
                    break;
                case Constants.WINSCREEN_SCENE:
                    gameCondition = GameCondition.Won;
                    break;
                case Constants.LOSESCREEN_SCENE:
                    gameCondition = GameCondition.Lost;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}