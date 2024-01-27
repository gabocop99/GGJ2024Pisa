using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carosello : MonoBehaviour
{
    public List<GameObject> hamsters;
    public Camera CarouselCamera;
    public float animationTime;
    public float rotationStep;

    private Coroutine coroutine;


    void Start()
    {
        int hamstersNumber = hamsters.Count;
        rotationStep = (360 / hamstersNumber);
    }

    public void RotateRight()
    {
        if (hamsters != null)
        {
            Vector3 to = new Vector3(0, rotationStep, 0);

            if (coroutine == null)
            {
                coroutine = StartCoroutine(RotationCoroutine(to));
            }
        }
    }

    public void RotateLeft()
    {
        if (hamsters != null)
        {
            Vector3 to = new Vector3(0, -rotationStep, 0);

            if (coroutine == null)
            {
                coroutine = StartCoroutine(RotationCoroutine(to));
            }
        }
    }

    private IEnumerator RotationCoroutine(Vector3 finalRotation)
    {
        float elapsedTime = 0;
        var startRotation = transform.rotation;
        while (elapsedTime <= animationTime)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(startRotation.eulerAngles + finalRotation), elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        coroutine = null;
    }
}
