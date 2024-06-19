using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float time;
    public float LockDownTime;


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
    private void Update()
    {
        time=time-Time.deltaTime;
        Debug.Log(time);
    }



}
