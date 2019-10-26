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
        _startY = _rectTransform.localPosition.y;
    }
    private void Update() {
        if (_isNeedToStop && _rectTransform.localPosition.y.Equals(_startY)) {
            Debug.Log("Stop");
            foreach (SpinItem item in _spinItems) {
                item.StopMoving();
            }
        }
    }

    public void StopRotating() {
        _isNeedToStop = true;
    }

    public void StartRotating() {
        _isNeedToStop = false;
        foreach (SpinItem item in _spinItems) {
            item.StartMoving(1000f);
        }
    }
}
