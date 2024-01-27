using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    [SerializeField] private GameObject _canva;
    [SerializeField] private GameObject _canva2;
   public void DeactivateCanva()
    {
        _canva.SetActive(false);
    }

    public void ActivateCanva2()
    {
        _canva2.SetActive(true);
    }
}
