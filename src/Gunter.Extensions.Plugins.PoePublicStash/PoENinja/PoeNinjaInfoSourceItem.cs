namespace Gunter.Extensions.Plugins.PoePublicStash.PoENinja
{
    public class PoeNinjaInfoSourceItem
    {
        public DateTimeOffset UtcDateTime { get; set; } = DateTimeOffset.UtcNow;
        public List<PoeNinjaInfoSourceItemCurrency> Currencies { get; set; } = new();
    }

    public class PoeNinjaInfoSourceItemCurrency
    {
        public int LeagueDay { get; set; }
        public string Currency { get; set; } = string.Empty;
        public double ChaosEquivalent { get; set; }
    }

}
