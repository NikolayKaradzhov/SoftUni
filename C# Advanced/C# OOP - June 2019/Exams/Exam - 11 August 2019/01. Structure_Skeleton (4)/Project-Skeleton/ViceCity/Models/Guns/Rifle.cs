namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialRifleDamage = 5;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - InitialRifleDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= InitialRifleDamage;
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return InitialRifleDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= InitialRifleDamage;
                return InitialRifleDamage;
            }

            return 0;
        }
    }
}