namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items = new List<Item>();
        public GildedRose(IList<Item> items) 
        { 
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items) 
            { 
                if (item.Name.Equals("Sulfuras, Hand of Ragnaros")) { continue; }

                CalculateItemQualityChange(item);                

                item.SellIn--;
            };
        }

        public void CalculateItemQualityChange(Item item)
        {
            switch (item.Name)
            {
                case string name when name.StartsWith("Aged Brie"):
                    SetAgedBrieQuality(item);
                    break;
                case string name when name.StartsWith("Backstage passes"):
                    SetBackStagePassQuality(item);
                    break;
                case string name when name.StartsWith("Conjured"):
                    SetConjuredQuality(item);
                    break;
                default:
                    SetGeneralItemQuality(item);
                    break;
            }

            if (item.Quality < 0) { item.Quality = 0; }

            if (item.Quality > 50) { item.Quality = 50; }
        }

        private void SetGeneralItemQuality(Item item)
        {
            item.Quality -= item.SellIn < 0 ? 2 : 1;
        }

        private void SetConjuredQuality(Item item)
        {
            item.Quality -= item.SellIn < 0 ? 4 : 2;
        }

        private void SetBackStagePassQuality(Item item)
        {
            switch (item.SellIn)
            {
                case < 0:
                    item.Quality = 0;
                    break;
                case <= 5:
                    item.Quality += 3;
                    break;
                case <= 10:
                    item.Quality += 2;
                    break;
                default:    
                    item.Quality++;
                    break;
            }
        }

        private void SetAgedBrieQuality(Item item)
        {
            item.Quality++;
        }
    }
}
