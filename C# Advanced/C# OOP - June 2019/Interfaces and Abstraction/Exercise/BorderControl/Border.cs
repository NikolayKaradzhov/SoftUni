namespace BorderControl
{
    public abstract class Border
    {
        private string id;

        protected Border(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get => this.id;

            private set => this.id = value;
        }
    }
}
