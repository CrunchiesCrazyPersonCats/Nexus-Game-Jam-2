using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pictomancer.Elements
{
    public class ElementPointDetection : MonoBehaviour
    {
        ElementDetection Parent;
        public int ID;
        bool completed = false;
        // Start is called before the first frame update
        void Start()
        {
            Parent = transform.parent.gameObject.GetComponent<ElementDetection>();
            Parent.MaxPoint++;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!completed && collision.CompareTag(Constants.TAG_MAGICQUILL))
            {
                Parent.PointCompleted++;
                completed = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.TAG_MAGICQUILL))
            {
                Parent.PointCompleted--;
                completed = false;
            }
        }
    }
}