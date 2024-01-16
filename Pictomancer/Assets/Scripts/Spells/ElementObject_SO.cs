using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "Pictomancer/New Element")]
public class ElementObject_SO : ScriptableObject, IObject
{
    public string _brozi; // name
    public GameObject _prefab;
    public Sprite _itemIcon;
}
