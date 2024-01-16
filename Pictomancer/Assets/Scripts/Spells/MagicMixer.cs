using System.Collections.Generic;
using UnityEngine;

public class MagicMixer : MonoBehaviour
{
    [Header("Spells")]
    public List<SpellObject_SO> spellList = new List<SpellObject_SO>();
    public GameObject failureManagement;
    Spell _spell = null;
    Form _form = null;
    Element _element = null;

    [Header("Anchors")]
    public Transform formAnchor;
    public Transform elementAnchor;
    public Transform spellAnchor;

    [Header("AnimationTimer")]
    bool _mixing = false;
    public float _maxTimer = 1f;
    float _currentTimer = 0f;

    private void Update()
    {
        if (_mixing && _spell == null) { UpdateAnimationTimer(Time.deltaTime); }
    }

    #region MixerIngredientsManagement
    public void AddForm(FormObject_SO form)
    {
        if (_form != null)
        {
            return;
        }
        GameObject newForm = Instantiate(form._prefab, formAnchor);
        _form = newForm.GetComponent<Form>();
        _mixing = _form && _element;
    }
    void RemoveForm()
    {
        if (_form != null)
        {
            Destroy(_form.gameObject);
            _form = null;
        }
    }
    public void AddElement(ElementObject_SO element)
    {
        if (_element != null)
        {
            return;
        }
        GameObject newElement = Instantiate(element._prefab, elementAnchor);
        _element = newElement.GetComponent<Element>();
        _mixing = _form && _element;
    }
    void RemoveElement()
    {
        if (_element != null)
        {
            Destroy(_element.gameObject);
            _element = null;
        }
    }
    #endregion

    #region SpellTransformation
    private void UpdateAnimationTimer(float deltaTime)
    {
        _currentTimer += deltaTime;
        if (_currentTimer >= _maxTimer)
        {
            _mixing = false;
            _currentTimer = 0f;
            CookTheMagic();
        }
    }

    private void CookTheMagic()
    {
        foreach(SpellObject_SO spell in spellList)
        {
            if (spell._form._brozi == _form.GetFormObject()._brozi &&
                spell._element._brozi == _element.GetElementObject()._brozi)
            {
                _spell = Instantiate(spell._prefab, spellAnchor).GetComponent<Spell>();
                RemoveForm();
                RemoveElement();
                return;
            }
        }
        _spell = Instantiate(failureManagement, spellAnchor).GetComponent<Spell>();
    }
    #endregion

    #region Interactions
    public IObject GrabSpell()
    {
        if (_spell != null)
        {
            SpellObject_SO so = _spell.GetSpellObject();
            Destroy(_spell.gameObject);
            return so;
        } else
        {
            return null;
        }
    }

    public IObject GrabFormObject()
    {
        if (_form == null || _mixing)
        {
            return null;
        } else
        {
            FormObject_SO so = _form.GetFormObject();
            RemoveForm();
            return so;
        }
    }

    public IObject GrabElementObject()
    {
        if (_element == null || _mixing)
        {
            return null;
        } else
        {
            ElementObject_SO so = _element.GetElementObject();
            RemoveElement();
            return so;
        }
    }
    #endregion
}
