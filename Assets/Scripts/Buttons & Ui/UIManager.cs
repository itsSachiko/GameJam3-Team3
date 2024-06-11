using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject creditsPanel;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnReturnToMain()
    {
        creditsPanel.SetActive(false);
    }
    public void OnShowCredits()
    {
        creditsPanel.SetActive(true);
    }
}
