using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class Carosello : MonoBehaviour
{
    public List<GameObject> hamsters;
    public Camera CarouselCamera;
    public float animationTime;
    public float rotationStep;
    public GameObject targetObject;

    public float radius;

    private Coroutine coroutine;


    void Awake()
    {
        int hamstersNumber = hamsters.Count;
        rotationStep = (360 / hamstersNumber);

        SetObjectsInCircle(radius);

    }

    public void SetObjectsInCircle(float radius)
    {
        int howMany = hamsters.Count;
        float angleSection = Mathf.PI * 2f / hamsters.Count;
        for (int i = 0; i < howMany; i++)
        {
            float angle = i * angleSection;
            Vector3 newPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            //newPos.y = yPosition;
            hamsters[i].transform.position = newPos;
        }
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
        var endRotation = Quaternion.Euler(startRotation.eulerAngles + finalRotation);
        while (elapsedTime <= animationTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / animationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        coroutine = null;
    }
}
