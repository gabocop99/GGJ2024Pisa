using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricetoGod : MonoBehaviour
{
    private string _badChoice1;
    private string _badChoice2;

    private string _storyToCheck;

    public bool IsStoryGood()
    {
        if(_storyToCheck != _badChoice1 && _storyToCheck != _badChoice2)
        {
            return true;
        }else return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _storyToCheck =  collision.gameObject.GetComponent<Criceto>().GetStory();
        IsStoryGood();
    }
}
