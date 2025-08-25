using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextChanger _textChanger;
    private double _deltaTime = 0;
    private bool _timerOn = false;


    public void StartTimer()
    {
        _timerOn = true;
    }

    public void StopTimer()
    {
        _timerOn = false;
    }

    public void ResetTimer()
    {
        _deltaTime = 0;
        _textChanger.SetText(_deltaTime.ToString("F2"));
    }

    void Update()
    {
        if (_timerOn)
        {
            _deltaTime += Time.fixedDeltaTime;
            _textChanger.SetText(_deltaTime.ToString("F2"));
        }
    }
}
