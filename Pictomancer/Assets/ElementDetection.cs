using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements
{
    Suvion,
    Perzys
}

public class ElementDetection : MonoBehaviour
{
    public int MaxPoint = 0;

    public Elements ThisElements;
    private int _pointcompleted;
    public int PointCompleted
    {
        get
        {
            return _pointcompleted;
        }
        set
        {
            _pointcompleted = value;
            if ( _pointcompleted == MaxPoint)
            {
                Debug.Log(ThisElements.ToString());
                // Unlocked element
            }
        }
    }
}
