using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Pictomancer/New Spell")]
public class SpellObject_SO : ScriptableObject
{
    public string _brozi;
    public GameObject _prefab;
    public FormObject_SO _form;
    public ElementObject_SO _element;
}