using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour {
    private float _speed = 300f;
    
    [SerializeField] private MainSpinItem _mainSpinItem;

    private void Start() {
        StartRotating();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            StopRotating();
        }
    }
    private void StartRotating() {
        _mainSpinItem.StartRotating();
    }

    public void StopRotating() {
        _mainSpinItem.StopRotating();
    }

}
