using Pictomancer.Enemies;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Colmeil : MonoBehaviour
{
    public ExchangeTileManager tileManager;
    bool _sorcering = false;
    SpellObject_SO _currentSpell = null;
    public SpellObject_SO SpellTest;
    float _currentTimer = 0f;

    [SerializeField] private float _spellLingering;
    [SerializeField] private LineRenderer _spellLine;

    [Header("Enemies")]
    //List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private WaveManager _waveManager;

    [Header("UI")]
    public GameObject spellUI;
    public Image spellIcon;
    public TMP_Text spellText;

    private void Start()
    {
        _spellLine.SetPosition(0, transform.position);
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
            if (_waveManager.EnnemiesList.Count > 0)
            {
                AttackClosestEnemies();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackClosestEnemies();
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
        //GameObject enemy = GetClosestEnemies();

        EnemieController closest = _waveManager.EnnemiesList[0];
        Invoke("HideSpellLine", _spellLingering);

        _spellLine.endColor = SpellTest._element._color;
        _spellLine.positionCount = 2;
        _spellLine.SetPosition(1, closest.transform.position);
        //closest.TakeDamage(_currentSpell._attackDamage, _currentSpell._element.ElementType);
        closest.TakeDamage(SpellTest._attackDamage, SpellTest._element.ElementType);

        // Attack Enemy
    }

    private void HideSpellLine()
    {
        _spellLine.positionCount = 1;
    }

    /*GameObject GetClosestEnemies()
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
    }*/
    #endregion
}
