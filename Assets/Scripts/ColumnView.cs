using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour {
    private float _speed = 300f;
    
    [SerializeField] private MainSpinItem _mainSpinItem;
    private bool _isNeedToRotate = false;

    private void Start() {
        //StartRotating();
    }

    private void Update() {
        Debug.Log(_isNeedToRotate);
        if (Input.GetButtonDown("Jump")) {
            _isNeedToRotate = !_isNeedToRotate;
            if (_isNeedToRotate) {
                StartRotating();
            } else {
                StopRotating();
            }
        }
    }
    private void StartRotating() {
        _mainSpinItem.StartRotating();
    }

    public void StopRotating() {
        _mainSpinItem.StopRotating();
    }

    IEnumerator StartSpin() {
        StartRotating();
        yield return new WaitForSeconds(0.5f);
        StopRotating();
    }

    public void OnButtonPressed() {
        StartCoroutine(StartSpin());
    }

}
