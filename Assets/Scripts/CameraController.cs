using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;

    private void Awake()
    {
        _camera = GetComponent<Camera>(); 
        _originalRotation = _camera.transform.rotation;
        _originalPosition = _camera.transform.position;

    }
    public void ResetPosition()
    {
        _camera.transform.position = _originalPosition;
        _camera.transform.rotation = _originalRotation;
    }

}
