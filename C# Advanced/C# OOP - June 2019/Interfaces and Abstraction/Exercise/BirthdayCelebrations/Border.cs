namespace FoodShortage
{
    public class Border
    {
        private string id;

        public Border(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get => this.id;

            set => this.id = value;
        }
    }
}