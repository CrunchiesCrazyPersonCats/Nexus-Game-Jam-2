using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Colmeil : MonoBehaviour
{
    public ExchangeTileManager tileManager;
    bool _sorcering = false;
    SpellObject_SO _currentSpell = null;
    float _currentTimer = 0f;

    [Header("UI")]
    public GameObject spellUI;
    public Image spellIcon;
    public TMP_Text spellText;


    private void Start()
    {
        spellUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_sorcering) 
        {
            SpellObject_SO so = tileManager.GetOldestSpell();
            if (so != null)
            {
                CastingASpell(so);
            }
        } else
        {
            UpdateSorceringTimer(Time.deltaTime);
        }
    }

    #region "CastingSpells"
    void CastingASpell(SpellObject_SO spell)
    {
        _currentSpell = spell;
        _sorcering = true;
        spellIcon.sprite = _currentSpell._itemIcon;
        spellText.text = ((int)_currentSpell._duration).ToString();
        spellUI.SetActive(true);
    }
    void UpdateSorceringTimer(float deltaTime)
    {
        _currentTimer += deltaTime;
        spellText.text = (_currentSpell._duration - ((int)_currentTimer)).ToString();

        if (_currentTimer >= _currentSpell._duration)
        {
            _sorcering = false;
            _currentTimer = 0f;
            _currentSpell = null;
            spellUI.SetActive(false);
        }
    }
    #endregion
}
