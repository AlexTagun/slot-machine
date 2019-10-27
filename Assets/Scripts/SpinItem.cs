using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinItem : MonoBehaviour {
    [SerializeField] private float _speed = 0;

    [SerializeField] private GameObject _topBorder;
    [SerializeField] private GameObject _bottomBorder;
    [SerializeField] private ItemRandomizer _itemRandomizer;

    private RectTransform _rectTransform;
    private Image _image; 

    private float _topY;
    private float _bottomY;

    private bool _isMoving = false;

    private void Start() {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _topY = _topBorder.transform.position.y;
        _bottomY = _bottomBorder.transform.position.y;
        SetRandomSprite();
    }

    private void FixedUpdate() {
        if(_isMoving) transform.Translate(0, -_speed * Time.deltaTime, 0);
       // Debug.Log(transform.position);

        if(transform.position.y <= _bottomY - _rectTransform.rect.height / 2) {
            transform.Translate(0, _topY - _bottomY + _rectTransform.rect.height, 0);
            OnPositionReset();
        }
    }

    private void OnPositionReset() {
        SetRandomSprite();
    }

    private void SetRandomSprite() {
        _image.sprite = _itemRandomizer.getRandomSprite();
    }

    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public void StartMoving(float speed) {
        _speed = speed;
        _isMoving = true;
    }

    public void StopMoving() {
        _speed = 0;
        _isMoving = false;
    }

}
