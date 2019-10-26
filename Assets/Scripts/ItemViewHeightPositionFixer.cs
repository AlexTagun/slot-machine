using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewHeightPositionFixer : MonoBehaviour {

    private RectTransform _rectTransform;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, _rectTransform.rect.height / 3);
        Debug.Log("done");
    }

}
