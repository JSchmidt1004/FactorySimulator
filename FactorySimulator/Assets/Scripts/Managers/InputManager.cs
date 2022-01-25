using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonComponent<InputManager>
{
    private PlayerInputActions playerControls;

    #region Callbacks
    #region PlayerMovement
    public delegate void PlayerLooked(Vector2 look);
    public PlayerLooked playerLookedCallback;

    public delegate void PlayerMoved(Vector2 movement);
    public PlayerMoved playerMovedCallback;

    public delegate void PlayerJumped();
    public PlayerJumped playerJumpedCallback;
    #endregion

    #region Tools

    #endregion

    #endregion

    #region UnityDefaults
    void Awake()
    {
        base.Awake();
        playerControls = new PlayerInputActions();
    }

    void OnEnable()
    {
        playerControls.Enable();

        playerControls.PlayerMovement.Move.performed += Move;
        playerControls.PlayerMovement.Look.performed += Look;
        playerControls.PlayerMovement.Jump.performed += Jump;
    }


    void OnDisable()
    {
        playerControls.Disable();

        playerControls.PlayerMovement.Move.performed -= Move;
        playerControls.PlayerMovement.Look.performed -= Look;
        playerControls.PlayerMovement.Jump.performed -= Jump;
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

    #region Invokes
    #region PlayerMovement
    private void Look(InputAction.CallbackContext obj)
    {
        playerLookedCallback?.Invoke(obj.ReadValue<Vector2>());
    }

    private void Move(InputAction.CallbackContext obj)
    {
        playerMovedCallback?.Invoke(obj.ReadValue<Vector2>());
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        playerJumpedCallback?.Invoke();
    }
    #endregion

    #region Tools

    #endregion

#endregion
}
