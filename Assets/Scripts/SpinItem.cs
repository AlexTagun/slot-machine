using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem : MonoBehaviour {
    [SerializeField] private float _speed = 0;

    [SerializeField] private GameObject _topBorder;
    [SerializeField] private GameObject _bottomBorder;

    private RectTransform _rectTransform;

    private float _topY;
    private float _bottomY;
    private float _currSpeed;
    private bool _isMoving = false;

    private void Start() {
        _rectTransform = GetComponent<RectTransform>();
        _topY = _topBorder.transform.position.y;
        _bottomY = _bottomBorder.transform.position.y;
    }

    private void FixedUpdate() {
        if(_isMoving) transform.Translate(0, -_currSpeed * Time.deltaTime, 0);
       // Debug.Log(transform.position);

        if(transform.position.y <= _bottomY - _rectTransform.rect.height / 2) {
            transform.Translate(0, _topY - _bottomY + _rectTransform.rect.height, 0);
        }
    }

    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public void StartMoving() {
        _currSpeed = _speed;
        _isMoving = true;
    }

    public void StartMoving(float speed) {
        _speed = speed;
        _currSpeed = _speed;
        _isMoving = true;
    }

    public void StopMoving() {
        _currSpeed = 0;
        _isMoving = false;
    }

}
