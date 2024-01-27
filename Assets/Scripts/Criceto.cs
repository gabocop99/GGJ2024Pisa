using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class Criceto : MonoBehaviour
{
    [SerializeField] private string _cricetoBackStory;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private string id;
    static private int _cricetoNumbers;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _selectionDistance;
    [SerializeField] private Vector3 _vectorCameraBehind;
    private bool _isTellingStory = false;

    //dati mmebro che ci servono: 

    //cose da passare tra le scene: backstory, mesh

    private void Start()
    {
        _cricetoNumbers++;
        _canvas.SetActive(false);
        id = "Criceto" + _cricetoNumbers.ToString();


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
        _canvas.SetActive(true);
    }

    public void DeactivateCanva()
    {
        _canvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!_isTellingStory)
        {
            CreateCopyAt(_camera.transform.position - _vectorCameraBehind);
            MoveCamera(_camera.transform.position - _vectorCameraBehind);
            _isTellingStory = true;
        }
    }

    private void MoveCamera(Vector3 toLook)
    {
        _camera.transform.position = -_vectorCameraBehind * 0.95f;
        _camera.transform.LookAt(toLook);
    }

    public void CreateCopyAt(Vector3 position)
    {
        Instantiate(this, position, Quaternion.identity);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("[COLLISION ENTER]");

    //    _canvas.SetActive(true);
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("[COLLISION EXIT]");
    //    _canvas.SetActive(false);
    //}

    public void Die()
    {
        //TODO
    }

}
