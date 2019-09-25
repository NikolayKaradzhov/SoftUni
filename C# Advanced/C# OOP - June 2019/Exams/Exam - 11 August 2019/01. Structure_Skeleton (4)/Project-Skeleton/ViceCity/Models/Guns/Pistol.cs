namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;
        int totalShots = 0;

        public Pistol(string name) 
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

            this.BulletsPerBarrel -= 1;
            totalShots++;

            return totalShots;
        }
    }
}