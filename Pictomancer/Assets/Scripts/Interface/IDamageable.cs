using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictomancer.Interface
{
    public interface IDamageable
    {
        public int Health { get; set; }
        public void Damage(int amount);
    }
}
