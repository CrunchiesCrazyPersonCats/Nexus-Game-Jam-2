using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    Perzys,
    Suvion
}

[CreateAssetMenu(fileName = "NewElement", menuName = "Pictomancer/New Element")]
public class ElementObject_SO : ScriptableObject, IObject
{
    public string _brozi; // brozi
    public ElementType ElementType;
    public GameObject _prefab;
    public Sprite _itemIcon;
    public Color _color;
}
