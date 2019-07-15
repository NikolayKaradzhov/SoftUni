namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                this.ValidateBoxSide(value, "Length");

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                this.ValidateBoxSide(value, "Width");

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                this.ValidateBoxSide(value, "Height");

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double result = (2 * this.Length * this.Width)
                            + (2 * this.Length * this.Height) 
                            + (2 * this.Width * this.Height);

            return result;
        }

        public double CalculateLateralSurfaceArea()
        {
            double result = (2 * this.Length * this.Height) 
                            + (2 * this.Width * this.Height);

            return result;
        }

        public double CalculateVolume()
        {
            double result = this.Length 
                            * this.Width 
                            * this.Height;

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }

        private void ValidateBoxSide(double value, string nameProperty)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameProperty} cannot be zero or negative.");
            }
        }
    }
}