using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwapper : MonoBehaviour
{
    public static SceneSwapper swapper;
    public enum SceneSelect
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        Credits
    }

    public SceneSelect currentScene;

    // Start is called before the first frame update
    void Start()
    {
        if (swapper == null)
        {
            swapper = this;
            DontDestroyOnLoad(swapper.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        // TODO: Replace these key presses with events from buttons in game
        if (Input.GetKeyDown(KeyCode.M))
        {
            ReturnToMenu();
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            GoToNextLevel();
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void ReturnToMenu()
    {
        currentScene = SceneSelect.MainMenu;
        LoadCurrentScene();
    }

    public void JumpToCredits()
    {
        currentScene = SceneSelect.Credits;
        LoadCurrentScene();
    }

    public void RestartLevel()
    {
        LoadCurrentScene();
    }

    public void GoToNextLevel()
    {
        switch (currentScene) {
            case SceneSelect.MainMenu:
                currentScene = SceneSelect.Level1;
                break;
            case SceneSelect.Level1:
                currentScene = SceneSelect.Level2;
                break;
            case SceneSelect.Level2:
                currentScene = SceneSelect.Level3;
                break;
            case SceneSelect.Level3:
                currentScene = SceneSelect.Credits;
                break;
            case SceneSelect.Credits:
                currentScene = SceneSelect.MainMenu;
                break;
        }
        LoadCurrentScene();
    }

    void LoadCurrentScene()
    {
        SceneManager.LoadScene((int)currentScene);
    }
}
