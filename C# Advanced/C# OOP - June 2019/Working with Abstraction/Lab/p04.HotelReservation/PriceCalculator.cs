namespace p04.HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator(double pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {
            this.PricePerDay = pricePerDay;
            this.NumberOfDays = numberOfDays;
            this.Season = season;
            this.DiscountType = discountType;
        }

        public double PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public Season Season { get; set; }

        public DiscountType DiscountType { get; set; }

        public double CalculatePrice()
        {
            double price = this.NumberOfDays * this.PricePerDay * (double)this.Season;

            price -= price * ((double)this.DiscountType / 100);

            return price;
        }
    }
}