using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwapper : MonoBehaviour
{
    public static SceneSwapper swapper;
    public bool isPaused;
    public enum SceneSelect
    {
        IntroCutscene,
        MainMenu,
        Level1Intro,
        Level1,
        Level2Intro,
        Level2,
        Level3Intro,
        Level3,
        Credits
    }

    public SceneSelect currentScene;

    public delegate void Paused();
    public static Paused pausegame = null;

    public delegate void UnPaused();
    public static UnPaused unpausegame = null;
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
        if ((int)currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            currentScene = (SceneSelect)SceneManager.GetActiveScene().buildIndex;
        }
        if (currentScene == SceneSelect.Level1 || currentScene == SceneSelect.Level2 || currentScene == SceneSelect.Level3)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                pausegame();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                GoToNextLevel();
            }
        } else if (currentScene == SceneSelect.MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public void ReturnToMenu()
    {
        isPaused = false;
        currentScene = SceneSelect.MainMenu;
        LoadCurrentScene();
    }

    public void JumpToCredits()
    {
        isPaused = false;
        currentScene = SceneSelect.Credits;
        LoadCurrentScene();
    }

    public void RestartLevel()
    {
        isPaused = false;
        currentScene--;
        LoadCurrentScene();
    }

    public void GoToNextLevel()
    {
        isPaused = false;
        if (currentScene == SceneSelect.Credits)
        {
            currentScene = SceneSelect.MainMenu;
        } else
        {
            currentScene++;
        }
        LoadCurrentScene();
    }

    void LoadCurrentScene()
    {
        isPaused = false;
        SceneManager.LoadScene((int)currentScene);
    }
}
