namespace GildedRose
{
    public class GildedRose
    {
        public List<Item> Items { get; private set; }
        public GildedRose(List<Item> items) 
        { 
            Items = items;
        }

        public void UpdateQuality()
        {
            Items.ForEach(item => {
                item.Process();
            });
        }
    }
}
