using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Criceto : MonoBehaviour
{
    [SerializeField] private string _cricetoBackStory;
    [SerializeField] private GameObject _canvas;

    //cose da passare tra le scene: backstory, mesh

    private void Start()
    {
        _canvas.SetActive(false);
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

    public void ActivateCanva()
    {
        Debug.Log("porcoddiomerda");
        _canvas.SetActive(true);
    }

    public void DeactivateCanva()
    {
        _canvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[COLLISION ENTER]");

        _canvas.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("[COLLISION EXIT]");
        _canvas.SetActive(false);
    }

    public void Die()
    {
        //TODO
    }

}
