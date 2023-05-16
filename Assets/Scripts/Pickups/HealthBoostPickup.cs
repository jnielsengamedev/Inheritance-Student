namespace Pickups
{
    public class HealthBoostPickup : Pickup
    {
        public float healthToAdd;
        
        protected override void Activate(PlayerController player)
        {
            player.maxHealth += healthToAdd;
            player.HealAllHealth();
        }
    }
}