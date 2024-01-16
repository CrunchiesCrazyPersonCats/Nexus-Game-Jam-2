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
    
    [Header("Enemies")]
    List<GameObject> _enemies = new List<GameObject>();

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
            if (_enemies.Count > 0)
            {
                AttackClosestEnemies();
            }
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

    #region "Murdering People, hum enemies"
    void AttackClosestEnemies()
    {
        GameObject enemy = GetClosestEnemies();

        // Attack Enemy
    }
    GameObject GetClosestEnemies()
    {
        GameObject closest = _enemies[0];
        float distance = Vector3.Distance(transform.position, closest.transform.position);

        foreach (GameObject enemy in _enemies)
        {
            float t = Vector3.Distance(transform.position, enemy.transform.position);
            if (t < distance)
            {
                closest = enemy;
                distance = t;
            }
        }
        return closest;
    }
    #endregion
}
