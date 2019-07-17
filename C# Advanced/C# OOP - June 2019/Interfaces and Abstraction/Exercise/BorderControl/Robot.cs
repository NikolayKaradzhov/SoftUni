namespace BorderControl
{
    public class Robot : Border
    {
        private string model;

        public Robot(string model, string id) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model
        {
            get => this.model;

            private set => this.model = value;
        }
    }
}