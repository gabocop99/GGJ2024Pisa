using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricetoGod : MonoBehaviour
{
    private string _badChoice1 = "Incidente domestico";
    private string _badChoice2 = "Salute";

    private string _storyToCheck;
    private Collider _collider;

    [SerializeField] private GameObject _player;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} collision with {other.gameObject.name}");
        _storyToCheck = other.gameObject.GetComponent<Criceto>().GetStory();
        if (!IsStoryGood())
        {
            _player.GetComponent<PlayerHandler>().HealthMeno();
        }
           
    }
}
