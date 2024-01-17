using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _isMovable = true;
    [SerializeField] private Animator _animator;
    public float speed;
    Vector2 _lookDirection = Vector2.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isMovable) Move();
    }

    private void Move()
    {
        Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
        transform.position += dir * speed * Time.deltaTime;

        // Can not look in diagonals
        if (!Mathf.Approximately(dir.x, 0.0f) || !Mathf.Approximately(dir.y, 0.0f))
        {
            _lookDirection = dir.normalized;

//            _lookDirection.Set(dir.x, dir.y);
// _lookDirection.Normalize();
        }
        _animator.SetFloat("Horizontal", _lookDirection.x);
        _animator.SetFloat("Vertical", _lookDirection.y);
        _animator.SetFloat("Magnitude", dir.magnitude);
    }
}
