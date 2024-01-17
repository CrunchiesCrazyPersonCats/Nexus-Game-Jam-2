using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Pictomancer/New Spell")]
public class SpellObject_SO : ScriptableObject, IObject
{
    public string _brozi;
    public int _attackDamage;
    public GameObject _prefab;
    public Sprite _itemIcon;
    public FormObject_SO _form;
    public ElementObject_SO _element;
    public int _duration;
}
