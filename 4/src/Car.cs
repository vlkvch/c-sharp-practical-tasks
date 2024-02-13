namespace Lab
{
    public class Car
    {
        private string make;
        private string model;
        private bool needsRepair;

        public string Make { get; set; }
        public string Model { get; set; }
        public bool NeedsRepair { get; set; }

        public Car(string make, string model, bool needsRepair)
        {
            Make = make;
            Model = model;
            NeedsRepair = needsRepair;
        }
    }
}
