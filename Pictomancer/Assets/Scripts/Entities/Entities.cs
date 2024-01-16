using Pictomancer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pictomancer
{
    public class Entities : MonoBehaviour, IDamageable
    {
        [Header("Entities")]
        [SerializeField] protected ElementObject_SO _element;
        public ElementObject_SO Element { get { return _element; } set { _element = value; } }
        protected int _health;
        public int Health { get { return _health; } set { Debug.Log("Health:" + value);  if (value > MaxHealth) { _health = MaxHealth; return; } _health = value; if (value <= 0) Death(); } }

        public int _maxHealth;
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        [SerializeField] protected int _attackDamage;

        protected virtual void Start()
        {
            Health = MaxHealth;
        }

        public virtual void TakeDamage(int damage, ElementType source)
        {
            if (source == _element.ElementType)
            {
                damage /= 2;
            }
            Health -= damage;
        }

        public virtual void Death()
        {
            Destroy(gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable obj))
            {
                obj.TakeDamage(_attackDamage, _element.ElementType);
            }
        }
    }
}
