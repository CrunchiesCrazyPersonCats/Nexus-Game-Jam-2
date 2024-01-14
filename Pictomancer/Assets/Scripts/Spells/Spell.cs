using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private SpellObject_SO _spellObject;

    public SpellObject_SO GetSpellObject() {  return _spellObject; }
}
