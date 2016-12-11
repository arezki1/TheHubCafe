namespace TheHubCafe.Models
{


    public class Order
    {
        public int OrderID { get; set; }
        public string PizzaName { get; set; }
        public string SaladName { get; set; }
        public string PastaName { get; set; }


        public Pizza Pizza { get; set; }
        public Salad Salad { get; set; }
        public Pasta Pasta { get; set; }
    }
}