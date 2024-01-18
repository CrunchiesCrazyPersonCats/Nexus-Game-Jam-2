using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pictomancer.Elements
{
    public class MouseDrawing : MonoBehaviour
    {

        Coroutine drawing;
        [SerializeField] private GameObject LinePrefab;
        Camera cam;
        List<Vector2> edgePos = new List<Vector2>();
        int _lmask;
        List<ElementPointDetection> _pointList = new List<ElementPointDetection>();


        private void Start()
        {
            _lmask = LayerMask.GetMask(Constants.LAYER_MAGIABOARD);

            cam = Camera.main;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    edgePos.Clear();
                    StartLine();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    edgePos.Clear();
                    FinishLine();
                }
            }
            else
            {
                int MaxIndex = transform.childCount;
                if (MaxIndex == 0) return;
                for (int i = MaxIndex - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }

        public void HardResetPen()
        {
            int MaxIndex = transform.childCount;
            if (MaxIndex == 0) return;
            for (int i = MaxIndex - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }


        void StartLine()
        {
            if (drawing != null)
            {
                StopCoroutine(drawing);
            }

            drawing = StartCoroutine(DrawLine());
        }

        void FinishLine()
        {
            StopCoroutine(drawing);
            foreach (ElementPointDetection point in _pointList)
            {
                point.UpdateHitStatus();
            }
            _pointList.Clear();
            /*GameObject go = transform.GetChild(transform.childCount - 1).gameObject;
            LineRenderer line = go.GetComponent<LineRenderer>();
            EdgeCollider2D edge = go.GetComponent<EdgeCollider2D>();
            for (int point = 0; point < line.positionCount; point++)
            {
                Vector3 lrp = line.GetPosition(point);
                edgePos.Add(new Vector2(lrp.x, lrp.y));
            }
            if (edgePos.Count > 4)
            {
                edge.SetPoints(edgePos);
            }
            else
            {
                Destroy(edge);
                go.AddComponent<CircleCollider2D>().radius = 0.2f;
            }*/
        }

        IEnumerator DrawLine()
        {
            GameObject go = Instantiate(LinePrefab, transform);
            LineRenderer line = go.GetComponent<LineRenderer>();
            line.positionCount = 0;
            Collider2D[] hits;
            while (true)
            {
                Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                hits = Physics2D.OverlapPointAll(pos, _lmask);
                foreach (Collider2D hit in hits)
                {
                    if (hit.TryGetComponent(out ElementPointDetection point))
                    {
                        _pointList.Add(point);
                    }
                    if (line.positionCount > 3 && line.GetPosition(line.positionCount - 2) == pos)
                    {
                        //mwein mwein
                    }
                    else
                    {
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, pos);
                    }

                }
                 yield return new WaitForFixedUpdate();
            }
        }
    }
}