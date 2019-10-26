using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRandomizer : MonoBehaviour
{
    [SerializeField] List<Sprite> _itemImageList;

    public Sprite getRandomSprite() {
        return _itemImageList[Random.RandomRange(0, _itemImageList.Count)];
    }
}
