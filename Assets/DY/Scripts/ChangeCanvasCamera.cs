using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasCamera : MonoBehaviour
{
    [SerializeField] private Camera[] _camera;

    [SerializeField] private Canvas _canvas;


    private void Start()
    {
        foreach (var camera in _camera)
        {
            camera.GetComponent<Camera>();
        }

        _canvas =_canvas. GetComponent<Canvas>();
    }


    public void ChangeCamera()
    {
        _canvas.worldCamera = _camera[1];
    }
}
