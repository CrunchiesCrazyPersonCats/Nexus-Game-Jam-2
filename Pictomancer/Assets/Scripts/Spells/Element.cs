using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private ElementObject_SO _elementObject;
    
    public ElementObject_SO GetElementObject() { return _elementObject; }
}
