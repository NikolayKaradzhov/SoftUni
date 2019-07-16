namespace Ferrari
{
    using System.Text;

    public class Ferrari : IDrive
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName { get; set; }

        public string Model => "488-Spider";

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}");

            return sb.ToString().TrimEnd();
        }
    }
}