using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricetoGod : MonoBehaviour
{
    public static CricetoGod instance;

    private string _badChoice1 = "Incidente domestico";
    private string _badChoice2 = "Salute";
    [SerializeField] public Camera _mainCamera;
    [SerializeField] public Camera _secondCamera;

    private string _storyToCheck;
    private Collider _collider;

    [SerializeField] private GameObject _player;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        instance = this;
    }

    public bool IsStoryGood()
    {
        if (_storyToCheck != null && _storyToCheck != _badChoice1 && _storyToCheck != _badChoice2)
        {
            Debug.Log("Buona storia");
            return true;
        }
        else return false;
    }
}
