using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeTile : MonoBehaviour
{
    ExchangeTileManager _tileManager;
    Spell _spell;
    public Transform anchor;

    private void Awake()
    {
        _tileManager = transform.parent.GetComponent<ExchangeTileManager>();
        _tileManager.RegisterTile(this);
    }

    #region "Interactions"
    public bool PutDownSpell(SpellObject_SO spellObject)
    {
        if (_spell == null)
        {
            GameObject newSpell = Instantiate(spellObject._prefab, anchor);
            _spell = newSpell.GetComponent<Spell>();
            return true;
        } else
        {
            return false;
        }
    }
    public SpellObject_SO GetSpell()
    {
        if ( _spell == null )
        {
            return null;
        } else
        {
            SpellObject_SO so = _spell.GetSpellObject();
            Destroy(_spell.gameObject);
            _spell = null;
            return so;
        }
    }
    #endregion
}
