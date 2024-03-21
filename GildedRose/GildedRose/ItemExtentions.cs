namespace GildedRose
{
    public static class ItemExtentions
    {
        public static void Process(this Item item)
        { 
            if(item.IsLegendaryItem()) { return; }

            item.CalculateItemQualityChange();

            item.SellIn--;
        }

        private static bool IsLegendaryItem(this Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Name)) { return false; }

            return LegendaryItems.ItemNames.Contains(item.Name);
        }

        private static void CalculateItemQualityChange(this Item item)
        {
            switch (item.Name)
            {
                case string name when name.StartsWith("Aged Brie"):
                    item.SetAgedBrieQuality();
                    break;
                case string name when name.StartsWith("Backstage passes"):
                    item.SetBackStagePassQuality();
                    break;
                case string name when name.StartsWith("Conjured"):
                    item.SetConjuredQuality();
                    break;
                default:
                    item.SetGeneralItemQuality();
                    break;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        private static void SetAgedBrieQuality(this Item item)
        {
            item.Quality++;
        }

        private static void SetBackStagePassQuality(this Item item)
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

        private static void SetConjuredQuality(this Item item)
        {
            item.Quality -= item.SellIn < 0 ? 4 : 2;
        }

        private static void SetGeneralItemQuality(this Item item)
        {
            item.Quality -= item.SellIn < 0 ? 2 : 1;
        }
    }
}
