using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonAutoCreateComponent<InputManager>
{
    private PlayerInputActions playerControls;

    #region UnityDefaults
    void Awake()
    {
        base.Awake();
        playerControls = new PlayerInputActions();
    }

    void OnEnable()
    {
        playerControls.Enable();

        //movement = playerInputActions.PlayerMovement.Move;
        //movement.Enable();

        //playerInputActions.PlayerMovement.Jump.performed += DoJump;
        //playerInputActions.PlayerMovement.Jump.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();

        //movement.Disable();
        //playerInputActions.PlayerMovement.Jump.Disable();
    }

    #endregion

    #region ToggleActiveMaps

    #region ActivateMaps

    public void ActivatePlayerMovement()
    {
        playerControls.PlayerMovement.Enable();
    }

    #endregion

    #region DeactivateMaps

    public void DeactivatePlayerMovement()
    {
        playerControls.PlayerMovement.Disable();
    }

    #endregion

    #endregion

    #region Gets

    public Vector2 GetPlayerMovement()
    {
        return playerControls.PlayerMovement.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.PlayerMovement.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumped()
    {
        return playerControls.PlayerMovement.Jump.triggered;
    }

    #endregion
}
