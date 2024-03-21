namespace GildedRose
{
    public class GildedRose
    {
        public List<Item> Items = new List<Item>();
        public GildedRose(List<Item> items) 
        { 
            Items = items;
        }

        public void UpdateQuality()
        {
            Items.ForEach(item => {
                if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    return;
                }

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

                ImplementQualityRestrictions(item);

                item.SellIn--;
            });
        }

        private void SetGeneralItemQuality(Item item)
        {
            item.Quality -= item.SellIn < 0 ? 2 : 1;
        }

        private void SetConjuredQuality(Item item)
        {
            item.Quality -= item.SellIn < 0 ? 4 : 2;
        }

        private void ImplementQualityRestrictions(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
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
