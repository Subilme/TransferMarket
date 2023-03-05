namespace TransferMarket.App.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Team { get; set; }
        public string Amplification { get; set; }
        public decimal Price { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}
