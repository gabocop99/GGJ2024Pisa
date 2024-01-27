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
    private Transform _originalPosition;
    [SerializeField] private GameObject _storyTellingCanvas;
    [SerializeField] private Collider _collider;

    //dati mmebro che ci servono: 

    //cose da passare tra le scene: backstory, mesh

    private void Start()
    {
        _cricetoNumbers++;
        //_canvas.SetActive(false);
        id = "Criceto" + _cricetoNumbers.ToString();

        _originalPosition = transform;

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

    public void ActivateCanva(GameObject canva)
    {
        canva.SetActive(true);
    }

    public void DeactivateCanva(GameObject canva)
    {
        canva.SetActive(false);
    }

    public void DeactivateCollider()
    {
        _collider.enabled = false;
    }

    private void OnMouseDown()
    {
        
        {
            CopyObjectAt(_camera.transform.position - _vectorCameraBehind);
            MoveCamera(_camera.transform.position - _vectorCameraBehind);
            
            DeactivateCanva(_canvas);
            ActivateCanva(_storyTellingCanvas);
        }
    }

    private void MoveCamera(Vector3 toLook)
    {
        _camera.transform.position = -_vectorCameraBehind * 0.95f;
        _camera.transform.LookAt(toLook);
    }

    public void TeleportAt(Vector3 position)
    {
        transform.position = position;
    }

    public void CopyObjectAt(Vector3 position)
    {
        var newCriceto = Instantiate(this, position, Quaternion.identity);
        newCriceto.DeactivateCollider();
    }


    public void Die()
    {
        //TODO
    }

}
