using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewForm", menuName = "Pictomancer/New Form")]
public class FormObject_SO : ScriptableObject, IObject
{
    public string _brozi; // name
    public GameObject _prefab;
    public Sprite _itemIcon;
}
