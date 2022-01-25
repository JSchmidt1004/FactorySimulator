using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField]
    private float clampY = 85f;

    [SerializeField]
    private Vector2 turnSpeed = Vector2.one;

    private Vector3 currentRotation;

    protected override void Awake()
    {
        if (currentRotation == null) currentRotation = transform.localRotation.eulerAngles;
        base.Awake();
    }

    private void OnEnable()
    {
        InputManager.Instance.playerLookedCallback += Look;
    }

    private void OnDisable()
    {
        InputManager.Instance.playerLookedCallback -= Look;
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                state.RawOrientation = Quaternion.Euler(-currentRotation.y, currentRotation.x, 0f);
            }
        }
    }

    private void Look(Vector2 look)
    {
        currentRotation.x += look.x * turnSpeed.x * Time.deltaTime;
        currentRotation.y += look.y * turnSpeed.y * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -clampY, clampY);
    }
    
}
