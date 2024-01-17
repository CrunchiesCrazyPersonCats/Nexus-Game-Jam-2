using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pictomancer.Elements
{
    public class ElementPointDetection : MonoBehaviour
    {
        ElementDetection Parent;
        public int ID;
        public bool completed = false;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
            Parent = transform.parent.gameObject.GetComponent<ElementDetection>();
            Parent.MaxPoint++;
        }

        public void UpdateHitStatus()
        {
            if (completed) return;
            completed = true;
            _spriteRenderer.enabled = completed;
            Parent.PointCompleted++;
        }

        public void SetUncomplete()
        {
            completed = false;
            _spriteRenderer.enabled = completed;
            Parent.PointCompleted--;
        }

        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!completed && collision.CompareTag(Constants.TAG_MAGICQUILL))
            {
                Debug.Log("Entered");
                Parent.PointCompleted++;
                completed = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Exited");
            if (collision.CompareTag(Constants.TAG_MAGICQUILL))
            {
                Parent.PointCompleted--;
                completed = false;
            }
        }*/
    }
}