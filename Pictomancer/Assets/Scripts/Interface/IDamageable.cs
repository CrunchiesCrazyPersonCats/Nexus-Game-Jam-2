using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictomancer.Interface
{
    public interface IDamageable
    {
        public ElementObject_SO Element { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public void TakeDamage(int amount, ElementType source);
        public void Death();
    }
}
