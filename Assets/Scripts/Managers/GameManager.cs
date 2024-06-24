using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float time;
    public float lockedDownTime;
    [SerializeField] Canvas LoseScreen;
    [SerializeField] Canvas WinScreen;
    [SerializeField] TMP_Text text;
    public int Counter;


    private void Awake()
    {
        Instance = this;
        if (Instance == null)
            Instance = this;
        MovementEnabled();
        PauseTime(1f);
    }
    private void OnEnable()
    {
        NPCStateManager.OnNpcDeath += WinCheck;
    }

    private void WinCheck()
    {
        if (Counter >= 4)
        {
            WinScreen.gameObject.SetActive(true);
            MovementDisabled();
            PauseTime(0);
        }
    }

    private void OnDisable()
    {
        NPCStateManager.OnNpcDeath -= WinCheck;
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
        int minute=Mathf.RoundToInt(time)/60;
        int seconds= Mathf.RoundToInt(time) %60;
        if (seconds < 10)
        {
            text.text = minute.ToString() + ":0" + seconds;
        }
        else{
            text.text = minute.ToString() + ":" + seconds;
        }
        Debug.Log(time);
        if(time<=0)
        {
            LoseScreen.gameObject.SetActive(true);
            MovementDisabled();
            PauseTime(0);
        }
    }



}
