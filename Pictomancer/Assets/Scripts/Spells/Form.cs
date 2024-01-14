using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    [SerializeField] private FormObject_SO _formObject;

    public FormObject_SO GetFormObject() { return _formObject; }
}
