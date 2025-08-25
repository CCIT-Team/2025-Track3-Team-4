using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    [SerializeField]
    private Renderer _renderer;

    [SerializeField]
    private Material _wheelMat;

    [SerializeField]
    public Shader _go, _stop, _backward;


    [ContextMenu("1")]
    public void SetGo()
    {
        _wheelMat.shader = _go;
    }

    [ContextMenu("2")]
    public void SetStop()
    {
        _wheelMat.shader = _stop;
    }

    [ContextMenu("3")]
    public void SetBackward()
    {
        _wheelMat.shader = _backward;
    }

}
