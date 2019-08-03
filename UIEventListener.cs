using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventListener : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject youeDiedMenu;
    private void Awake()
    {
        SceneSwapper.pausegame += ShowPauseMenu;
    }
    void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    void YouWereCaught()
    {
        youeDiedMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneSwapper.swapper.ReturnToMenu();
    }

    public void RestartLevel()
    {
        SceneSwapper.swapper.RestartLevel();
    }

    public void UnPause()
    {
        SceneSwapper.swapper.isPaused = false;
        pauseMenu.SetActive(false);
        SceneSwapper.unpausegame();
    }
}
