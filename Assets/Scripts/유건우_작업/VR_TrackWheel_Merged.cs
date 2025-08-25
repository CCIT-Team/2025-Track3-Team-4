using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VR_TrackWheel_Merged : MonoBehaviour
{
    public WheelCollider[] leftWheels;   // 왼쪽 트랙
    public WheelCollider[] rightWheels;  // 오른쪽 트랙

    public float motorTorque = 500f;     // 구동 토크
    public float brakeTorque = 1000f;    // 브레이크 토크

    // 외부에서 주입할 전/후진 방향 (-1, 0, 1)
    int _leftDir = 0;
    int _rightDir = 0;

    // VR 어댑터/다른 스크립트에서 호출
    public void SetLeftTrack(int dir) { _leftDir = Mathf.Clamp(dir, -1, 1); }
    public void SetRightTrack(int dir) { _rightDir = Mathf.Clamp(dir, -1, 1); }

    void FixedUpdate()
    {
        // 왼쪽 바퀴
        foreach (WheelCollider wc in leftWheels)
        {
            wc.motorTorque = _leftDir * motorTorque;
            wc.brakeTorque = (_leftDir == 0) ? brakeTorque : 0;
        }

        // 오른쪽 바퀴
        foreach (WheelCollider wc in rightWheels)
        {
            wc.motorTorque = _rightDir * motorTorque;
            wc.brakeTorque = (_rightDir == 0) ? brakeTorque : 0;
        }
    }
}
