using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Criceto firstCriceto;

    private void Start()
    {
        //firstCriceto = FindAnyObjectByType<Criceto>();
        //transform.LookAt(firstCriceto.transform.position);
        transform.LookAt(Vector3.zero);
    }
}
