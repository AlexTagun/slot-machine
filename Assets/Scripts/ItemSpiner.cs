using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpiner : MonoBehaviour {
    [SerializeField] private float _speed = 300;
    [SerializeField] private GameObject _topBorder;
    [SerializeField] private GameObject _bottomBorder;

    private RectTransform _rectTransform;

    private float _topY;
    private float _bottomY;

    private void Start() {
        _rectTransform = GetComponent<RectTransform>();
        _topY = _topBorder.transform.position.y;
        _bottomY = _bottomBorder.transform.position.y;
    }
    private void FixedUpdate() {
        //MoveY(-_speed * Time.deltaTime);
        transform.Translate(0, -_speed * Time.deltaTime, 0);
        Debug.Log(transform.position);

        if(transform.position.y <= _bottomY - _rectTransform.rect.height / 2) {
           // setY(_topY + _rectTransform.rect.height / 2);
            transform.Translate(0, 400, 0);
        }
    }

    private void MoveY(float dY) {
        Vector3 pos = transform.position;
        pos.y += dY;
        transform.position = pos;
    }

    private void setY(float y) {
        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;
    }

}
