using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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
