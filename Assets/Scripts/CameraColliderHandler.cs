using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Criceto"))
        {
            collision.gameObject.GetComponent<Criceto>().ActivateCanva();
        }
    }
}
