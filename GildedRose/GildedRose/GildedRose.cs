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
                item.Process();
            }
        }
    }
}
