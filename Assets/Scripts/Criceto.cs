using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;

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
    //[SerializeField] private float _animationTime;
    [SerializeField] private List<Sprite> _backStory;
    [SerializeField] private BackStoryController _backStoryController;

    private Criceto SelfCopy;
    //private Coroutine _coroutine;

    //dati mmebro che ci servono: 

    //cose da passare tra le scene: backstory, mesh

    private void Start()
    {
        _cricetoNumbers++;
        //_canvas.SetActive(false);
        id = "Criceto" + _cricetoNumbers.ToString();

        _originalPosition = transform;

        _backStoryController = FindAnyObjectByType<BackStoryController>();
        //BackStoryBaloon textCanva = FindObjectOfType<BackStoryBaloon>();
        ////GameObject textCanvas = GameObject.Find("BaloonCriceto");
        //if (textCanva != null)
        //{
        //    textCanva.gameObject.GetComponent<TextMeshPro>().text = _cricetoBackStory;
        //}
        GameObject backStory = GameObject.FindGameObjectWithTag("BackStory");
        //if (backStory != null)
           // _backStory = ;
    }

    private void Update()
    {
        transform.LookAt(_camera.transform.position);
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
        Vector3 targetPosition = new Vector3(8.39f, -3.61f, -54.17f);
        SelfCopy = CopyObjectAt(targetPosition);
        MoveCamera(_camera.transform.position - _vectorCameraBehind);
        //Vector3 to = new Vector3(0, 0, -30);
        DeactivateCanva(_canvas);
        ActivateCanva(_storyTellingCanvas);
        _backStoryController.DisplayBackStory(_backStory);
        //StartCoroutine(RotationCoroutine());
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

    public Criceto CopyObjectAt(Vector3 position)
    {
        var newCriceto = Instantiate(this, position, Quaternion.identity);
        newCriceto.name = "CopiaCriceto";
        newCriceto.DeactivateCollider();
        return newCriceto;
    }

    //public void DestroyCopy()
    //{
    //    Destroy(SelfCopy);
    //}

    //private IEnumerator RotationCoroutine()
    //{
    //    float elapsedTime = 0;
    //    var startPosition = _camera.transform.position;
    //    var endPosition = new Vector3(5,0,-20);
    //    while (elapsedTime <= _animationTime)
    //    {
    //        float x = elapsedTime / _animationTime;
    //        _camera.transform.position = Vector3.Lerp(startPosition, endPosition ,1 - Mathf.Pow(1 - x, 4));
    //        elapsedTime += Time.deltaTime;

    //        yield return null;
    //    }
    //    _camera.transform.position = endPosition;
    //    _coroutine = null;
    //}
}
