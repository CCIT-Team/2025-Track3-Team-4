using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [SerializeField]
    private TextChanger _textChanger;
    [SerializeField]
    private Timer _timer;
    [ContextMenu("1")]
    public void ActivateWaterSource()
    {
        _textChanger.SetText("On");
        _timer.StartTimer();
    }
    [ContextMenu("12")]
    public void DeactivateWaterSource() 
    {
        _textChanger.SetText("Off");
        _timer.StopTimer();
    }
    [ContextMenu("13")]
    public void ClearWater()
    {
        _timer.ResetTimer();
    }
}
