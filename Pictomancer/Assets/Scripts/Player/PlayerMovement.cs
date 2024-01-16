using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _isMovable = true;
    public float speed;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isMovable) Move();
    }

    private void Move()
    {
        Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
        transform.position += dir * speed * Time.deltaTime;
    }
}
