using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCameraHandler : MonoBehaviour
{
    public float radius;
    public Criceto firstCriceto;
    public Transform carouselCenter;

    private void SetCameraCentered()
    {
        firstCriceto = FindAnyObjectByType<Criceto>();
        Vector3 direction = firstCriceto.transform.position - carouselCenter.position;
        //transform.position = transform.position * direction.normalized;
    }


}
