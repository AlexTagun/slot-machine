using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpinItem : MonoBehaviour {
    [SerializeField] ColumnView _columnView;
    [SerializeField] SpinItem[] _spinItems;
    private bool _isNeedToStop = false;
    private RectTransform _rectTransform;
    private float _startY;
    private float _startSpeed = 1000f;
    private float _currSpeed;


    private void Start() {
        _rectTransform = GetComponent<RectTransform>();
        _startY = _rectTransform.offsetMax.y;
        Debug.Log(_startY);
        _currSpeed = _startSpeed;
    }
    private void FixedUpdate() {
       // Debug.Log(_rectTransform.offsetMax.y);
        if (_isNeedToStop) {
            if (IsCloseToStartPosition()) {
                _currSpeed -= 500 * Time.deltaTime;
                if (_currSpeed < 150) _currSpeed = 150f;
                Debug.Log(_currSpeed);
                SetSpeed(_currSpeed);
            }
            if (IsStartPosition()) {
                Debug.Log("Stop");
                foreach (SpinItem item in _spinItems) {
                    item.StopMoving();
                }
            }
            
        }
    }

    public void StopRotating() {
        _isNeedToStop = true;
    }

    private bool IsStartPosition() {
        float dif = _rectTransform.offsetMax.y - _startY;
        if (Mathf.Abs(dif) < 3) return true;
        else return false;
        //Mathf.RoundToInt(_rectTransform.offsetMax.y).Equals(Mathf.RoundToInt(_startY))
    }

    private bool IsCloseToStartPosition() {
        if (_rectTransform.offsetMax.y < _startY) return true;
        else return false;
    }

    private void SetSpeed(float speed) {
        foreach (SpinItem item in _spinItems) {
            item.SetSpeed(speed);
        }
    }

    public void StartRotating() {
        _isNeedToStop = false;
        _currSpeed = _startSpeed;
        foreach (SpinItem item in _spinItems) {
            item.StartMoving(_startSpeed);
        }
    }
}
