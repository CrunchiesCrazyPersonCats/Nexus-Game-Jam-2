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
        public int Health { get { return _health; } set { if (value > MaxHealth) { _health = MaxHealth; return; } _health = value; if (value <= 0) Death(); } }

        public int _maxHealth;
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        [SerializeField] protected int _attackDamage;
        [SerializeField] protected Animator _animator;

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
            if (_animator != null)
            {
                _animator.SetTrigger("TakeDamage");
            }
            // TODO Elemental VFX depending on the source type
        }

        public virtual void Death()
        {
            if (_animator != null)
            {
                _animator.SetTrigger("Death");
            }
            Destroy(gameObject);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(gameObject.tag))
            {
                return;
            }
            if (collision.gameObject.TryGetComponent(out IDamageable obj))
            {
                obj.TakeDamage(_attackDamage, _element.ElementType);
            }
        }
    }
}
