using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pictomancer.Elements
{
    public class ElementDetection : MonoBehaviour
    {
        public int MaxPoint = 0;

        public SpellObject_SO ThisSpell;
        private int _pointcompleted;
        public int PointCompleted
        {
            get
            {
                return _pointcompleted;
            }
            set
            {
                _pointcompleted = Math.Clamp(value, 0, MaxPoint);
                if (_pointcompleted == MaxPoint)
                {
                    MagiaBoard.Instance.UnlockElement(ThisSpell);
                    Debug.Log(ThisSpell._element._brozi);
                }
            }
        }

        public void ResetBoard()
        {
            StartCoroutine(HideDetector());
        }
        IEnumerator HideDetector()
        {
            int child = transform.childCount;
            yield return new WaitForSecondsRealtime(1f);
            for (int i = 0; i < child; i++)
            {
                transform.GetChild(i).GetComponent<ElementPointDetection>().SetUncomplete();
            }
        }
    }

}