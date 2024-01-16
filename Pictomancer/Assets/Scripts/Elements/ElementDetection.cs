using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pictomancer.Element
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
                _pointcompleted = value;
                if (_pointcompleted == MaxPoint)
                {
                    Debug.Log(ThisSpell._element._brozi);
                }
            }
        }
    }

}