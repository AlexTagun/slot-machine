using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpinItem : MonoBehaviour {
    [SerializeField] ColumnView _columnView;
    [SerializeField] SpinItem[] _spinItems;
    private bool _isNeedToStop = false;
    private RectTransform _rectTransform;
    private float _startY;

    private void Start() {
        _rectTransform = GetComponent<RectTransform>();
        _startY = _rectTransform.offsetMax.y;
        Debug.Log(_startY);
    }
    private void Update() {
        Debug.Log(_rectTransform.offsetMax.y);
        if (_isNeedToStop && IsStartPosition()) {
            Debug.Log("Stop");
            foreach (SpinItem item in _spinItems) {
                item.StopMoving();
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

    public void StartRotating() {
        _isNeedToStop = false;
        foreach (SpinItem item in _spinItems) {
            item.StartMoving(2000f);
        }
    }
}
