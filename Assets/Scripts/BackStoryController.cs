using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackStoryController : MonoBehaviour
{
    [SerializeField] private List<float> _imageTime;
    private List<Sprite> sprites;
    private bool _isDisplaying = false;
    private bool _isAnimating = false;
    private int _currentIndex = 0;

    private float _elapsedTime = 0;
    private float _timeToWait = 0;

    [SerializeField] private Image _image = null;
    private void Awake()
    {
        _image.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isDisplaying && sprites != null)
        {

            if (!_isAnimating)
            {
                _isAnimating = true;
                _elapsedTime = 0;
                _timeToWait = _imageTime[_currentIndex];
                _image.sprite = sprites[_currentIndex];
            }
            else
            {
                if (_elapsedTime < _timeToWait)
                {
                    _elapsedTime += Time.deltaTime;
                }
                else
                {
                    _currentIndex++;
                    if (_currentIndex == 3)
                    {
                        _currentIndex = 0;
                    }
                    _isAnimating = false;

                }
            }
            #region a
            //Debug.Log("cacca addosso puzza MOLTO");
            //var startTime = Time.time;
            //var elapsedTime = Time.time - startTime;
            //if (elapsedTime <= _firstImageTime)
            //{
            //    GetComponent<Image>().sprite = sprites[0];
            //}
            //else if (elapsedTime <= _secondImageTime)
            //{
            //    GetComponent<Image>().sprite = sprites[1];
            //}
            //else if (elapsedTime <= _thirdImageTime)
            //{
            //    GetComponent<Image>().sprite = sprites[2];
            //}
            //else
            //{
            //    startTime = Time.time;
            //    elapsedTime = Time.time - startTime; ;
            //}
            #endregion
        }
    }

    public void DisplayBackStory(List<Sprite> sprites)
    {
        this.sprites = sprites;
        _isDisplaying = true;
        _image.gameObject.SetActive(true);
    }
    public void resetAll()
    {
        _isDisplaying = false;
        _isAnimating = false;
        _currentIndex = 0;

        _elapsedTime = 0;
        _timeToWait = 0;
        sprites.Clear();
        _image.gameObject.SetActive(false);
    }
}
