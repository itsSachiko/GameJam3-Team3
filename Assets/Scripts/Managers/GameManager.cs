using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] float time;


    private void Awake()
    {
        Instance = this;
        if (Instance == null)
            Instance = this;
    }




    void MovementDisabled()
    {
        InputManager.ActionMap.Player.Disable();
    }
    void MovementEnabled()
    {
        InputManager.ActionMap.Player.Enable();
    }
    void PauseTime(float timer)
    {
        Time.timeScale = timer;
    }




}
