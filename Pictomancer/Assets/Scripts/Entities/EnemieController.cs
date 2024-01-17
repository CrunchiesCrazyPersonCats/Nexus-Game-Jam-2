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
        public WaveManager WaveManagerRef;

        protected override void Start()
        {
            base.Start();
            _spriteRenderer.color = _element._color;
            _body.velocity = Vector3.right * MoveSpeed;
            Destroy(gameObject, _lifeSpawn);
        }

        public override void Death()
        {
            WaveManagerRef.EnnemiesList.Remove(this);
            base.Death();
        }
    }
}