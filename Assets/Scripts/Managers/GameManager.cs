using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float time;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text text;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
            Instance = this;
        MovementEnabled();
        PauseTime(1f);
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
        text.text =time.ToString();
        Debug.Log(time);
        if(time<=0)
        {
            canvas.gameObject.SetActive(true);
            MovementDisabled();
            PauseTime(0);
        }
    }



}
