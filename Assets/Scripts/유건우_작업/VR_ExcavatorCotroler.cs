using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VR_ExcavatorController : MonoBehaviour
{
    [Header("Stick Input")]
    public InputActionReference leftStick;   // XRI LeftHand Locomotion/Move
    public InputActionReference rightStick;  // XRI RightHand Locomotion/Move

    [Header("Button Input")]
    public InputActionReference leftForwardBtn;   // 왼손 A버튼 같은거
    public InputActionReference leftBackwardBtn;  // 왼손 B버튼
    public InputActionReference rightForwardBtn;  // 오른손 X버튼
    public InputActionReference rightBackwardBtn; // 오른손 Y버튼

    void OnEnable()
    {
        leftStick.action.Enable();
        rightStick.action.Enable();
        leftForwardBtn.action.Enable();
        leftBackwardBtn.action.Enable();
        rightForwardBtn.action.Enable();
        rightBackwardBtn.action.Enable();
    }

    void OnDisable()
    {
        leftStick.action.Disable();
        rightStick.action.Disable();
        leftForwardBtn.action.Disable();
        leftBackwardBtn.action.Disable();
        rightForwardBtn.action.Disable();
        rightBackwardBtn.action.Disable();
    }

    void Update()
    {
        // --- 스틱 ---
        Vector2 l = leftStick.action.ReadValue<Vector2>();
        Vector2 r = rightStick.action.ReadValue<Vector2>();

        // Arm (Up/Down) & Swing (Left/Right)
        ControlArm(l.y);
        ControlSwing(l.x);

        // Boom (Up/Down) & Bucket (Open/Close)
        ControlBoom(r.y);
        ControlBucket(r.x);

        // --- 버튼 ---
        if (leftForwardBtn.action.IsPressed()) ControlLeftTrack(1);
        else if (leftBackwardBtn.action.IsPressed()) ControlLeftTrack(-1);
        else ControlLeftTrack(0);

        if (rightForwardBtn.action.IsPressed()) ControlRightTrack(1);
        else if (rightBackwardBtn.action.IsPressed()) ControlRightTrack(-1);
        else ControlRightTrack(0);
    }

    // --- 실제 기능 함수들 ---
    void ControlArm(float value) { Debug.Log("Arm " + value); }
    void ControlSwing(float value) { Debug.Log("Swing " + value); }
    void ControlBoom(float value) { Debug.Log("Boom " + value); }
    void ControlBucket(float value) { Debug.Log("Bucket " + value); }

    void ControlLeftTrack(int dir) { Debug.Log("LeftTrack " + dir); }
    void ControlRightTrack(int dir) { Debug.Log("RightTrack " + dir); }
}

