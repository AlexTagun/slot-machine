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
        //Debug.Log(_rectTransform.localPosition.y);
        _startY = _rectTransform.localPosition.y;
        //Debug.Log(_startY);
    }
    private void Update() {
        //Debug.Log(_isNeedToStop);
        //Debug.Log(Mathf.RoundToInt(_rectTransform.localPosition.y).Equals(Mathf.RoundToInt(_startY)));
        if (_isNeedToStop && Mathf.RoundToInt(_rectTransform.localPosition.y).Equals(Mathf.RoundToInt(_startY))) {
            //Debug.Log("Stop");
            //Debug.Log(_rectTransform.localPosition.y);
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
            item.StartMoving(300f);
        }
    }
}
