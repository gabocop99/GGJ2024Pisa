using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Criceto : MonoBehaviour
{
    [SerializeField] private string _cricetoBackStory;

    //cose da passare tra le scene: backstory, mesh

    private void Start()
    {
        //BackStoryBaloon textCanva = FindObjectOfType<BackStoryBaloon>();
        ////GameObject textCanvas = GameObject.Find("BaloonCriceto");
        //if (textCanva != null)
        //{
        //    textCanva.gameObject.GetComponent<TextMeshPro>().text = _cricetoBackStory;
        //}
        GameObject backStory = GameObject.FindGameObjectWithTag("BackStory");
        if (backStory != null)
            backStory.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _cricetoBackStory;
    }

    public void Die()
    {
        //TODO
    }

}
