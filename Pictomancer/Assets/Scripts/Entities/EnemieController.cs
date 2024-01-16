using Pictomancer.Interface;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Pictomancer.Enemies
{

    public class EnemieController : Entities
    {
        [Header("Enemies")]
        public float MoveSpeed;

        [SerializeField] private float _lifeSpawn;

        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private SpriteRenderer _spriteRenderer;


        private void Start()
        {
            _spriteRenderer.color = _element._color;
            Health = MaxHealth;
            _body.velocity = Vector3.right * MoveSpeed;
            Destroy(gameObject, _lifeSpawn);
        }
    }
}