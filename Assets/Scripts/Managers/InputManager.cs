using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static ActionMap ActionMap;

    static InputManager()
    {
        ActionMap = new ActionMap();
        ActionMap.Enable();
    }

    public static Vector2 Movement => ActionMap.Player.Movement.ReadValue<Vector2>();

}
