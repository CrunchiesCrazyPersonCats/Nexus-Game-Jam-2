using Pictomancer.Enemies;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Colmeil : MonoBehaviour
{
    public ExchangeTileManager tileManager;
    bool _sorcering = false;
    SpellObject_SO _currentSpell = null;
    public SpellObject_SO SpellTest;
    float _currentTimer = 0f;
    Coroutine Spelling;

    [SerializeField] private float _spellLingering;
    [SerializeField] private LineRenderer _spellLine;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _spellStartPoint;

    [Header("Enemies")]
    //List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private WaveManager _waveManager;

    [Header("UI")]
    public GameObject spellUI;
    public Image spellIcon;
    public TMP_Text spellText;


    [SerializeField] float _reCastSpeed;
    float _nextShot = 0.0f;

    public Pictomancer.Entities colmeilLife;

    private void Start()
    {
        _spellLine.SetPosition(0, _spellStartPoint.position);
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
            if (_waveManager.EnnemiesList.Count > 0 && _nextShot + _reCastSpeed < Time.time)
            {
                if (_animator)
                {
                    _animator.SetTrigger("Cast");
                }
                _nextShot = Time.time;
                //AttackClosestEnemies();
            }
        }

        if (colmeilLife.Health <= 0)
        {
            SceneManager.LoadScene(Constants.LOSESCREEN_SCENE);
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && _waveManager.EnnemiesList.Count > 0)
        {
            if (_animator)
            {
                _animator.SetTrigger("Cast");
            }
            //AttackClosestEnemies();
        }*/
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
    public void AttackClosestEnemies()
    {
        if (Spelling != null)
        {
            HideSpellLine();
            StopCoroutine(Spelling);
        }
        Spelling = StartCoroutine(SpellAnimation());
    }

    IEnumerator SpellAnimation()
    {
        if (_waveManager.EnnemiesList.Count != 0)
        {
            EnemieController closest = _waveManager.EnnemiesList[0];
            StartCoroutine(ApplyDamage(closest));

            float timer = _spellLingering;
            _spellLine.endColor = _currentSpell._element._color;
            _spellLine.positionCount = 2;
            while (closest)
            {
                _spellLine.SetPosition(1, closest.transform.position);
                yield return new WaitForFixedUpdate();
                timer -= Time.fixedDeltaTime;
                if (timer < 0f)
                {
                    break;
                }
            }
            HideSpellLine();
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator ApplyDamage(EnemieController closest)
    {
        int attack = _currentSpell._attackDamage;
        ElementType elemType = _currentSpell._element.ElementType;
        yield return new WaitForSeconds(_spellLingering);
        if (closest != null)
        {
            closest.TakeDamage(attack, elemType);
        }
        //closest.TakeDamage(SpellTest._attackDamage, SpellTest._element.ElementType);
    }

    private void HideSpellLine()
    {
        _spellLine.positionCount = 1;
    }
    #endregion
}
