using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]Canvas pauseMenu;
    bool isPaused=false;

    private void OnEnable()
    {
        InputManager.ActionMap.UIandMenu.Pause.performed+=Pause;
    }

    private void OnDisable()
    {
        InputManager.ActionMap.UIandMenu.Pause.performed -= Pause;

    }

    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            isPaused=false;
            Resume();
        }
        else
        {
            isPaused = true;
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        GameManager.Instance.MovementDisabled();
        GameManager.Instance.PauseTime(0);
    }
    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        GameManager.Instance.MovementEnabled();
        GameManager.Instance.PauseTime(1);
    }


}
