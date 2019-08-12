namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        private int totalShots = 0;

        public Rifle(string name) 
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel <= 0)
            {
                this.TotalBullets -= BULLETS_PER_BARREL;
                this.BulletsPerBarrel += BULLETS_PER_BARREL;
            }

            this.BulletsPerBarrel -= 5;
            totalShots++;

            return totalShots;
        }
    }
}