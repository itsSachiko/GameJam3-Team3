using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 dir;
    Vector2 dirSaved;
    bool isDashingCooldownActive;
    bool isDashing;

    [Header("Dash Stats")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTimer;
    [SerializeField] float dashCooldown;

    [Header("Player Stats")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private void OnEnable()
    {
        InputManager.ActionMap.Player.Dash.performed += Dash;
    }

    private void OnDisable()
    {
        InputManager.ActionMap.Player.Dash.performed -= Dash;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //if is dashing == true return;
        if (InputManager.Movement != Vector2.zero && isDashing == false)
        {
            dirSaved = InputManager.Movement;
        }
        dir = InputManager.Movement;
        //transform.forward=new Vector3(dir.x, 0,dir.y);
        transform.position += new Vector3(dir.x, 0, dir.y) * speed * Time.fixedDeltaTime;

        if (dir != Vector2.zero)
        {
            var targetRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (isDashingCooldownActive == false)
        {
            StartCoroutine(DashTimer());
        }

    }
    IEnumerator DashTimer()
    {
        float timer = 0;
        isDashingCooldownActive = true;

        isDashing = true;
        while (timer < dashTimer)
        {
            transform.position += new Vector3(dirSaved.x, 0, dirSaved.y) * dashSpeed * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        isDashingCooldownActive = false;
    }
}

//is dashing disattiva dopo che finisce il dash
