using System.Collections.Generic;

namespace FancyPants.Interfaces
{
    public interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        List<IItem> DropTable { get; set; }
        void Attack();
        string Description { get; set; }

        void Die();
        void DealDamage(int damage);
    }
}