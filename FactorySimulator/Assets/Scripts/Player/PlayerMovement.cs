using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region UnityDefaults
    void Awake()
    {
        
    }

    private void OnEnable()
    {
        InputManager.Instance.playerMovedCallback += Move;
        InputManager.Instance.playerJumpedCallback += Jump;
    }


    private void OnDisable()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    private void Move(Vector2 movement)
    {
        throw new NotImplementedException();
    }

    private void Jump()
    {
        throw new NotImplementedException();
    }


}
