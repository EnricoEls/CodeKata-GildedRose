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
            


            foreach (Item item in Items) {
                if (item.Name.StartsWith("Sulfuras"))
                {
                    continue;
                }

                if (item.Name.StartsWith("Aged Brie"))
                {
                    item.Quality++;
                }

                if (item.Name.StartsWith("Backstage passes"))
                {
                    item.Quality++;

                    if (item.SellIn <= 10)
                    {
                        item.Quality++;
                    }

                    if(item.SellIn <= 5)
                    {
                        item.Quality++;
                    }

                    if(item.SellIn < 0)
                    {
                        item.Quality = 0;
                    }
                }

                if (item.Quality > 0 && !item.Name.StartsWith("Aged Brie") && !item.Name.StartsWith("Backstage passes"))
                { 
                    item.Quality = item.SellIn < 0 ? item.Quality - 2 : item.Quality - 1 ;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }

                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }

                item.SellIn--;
            }

            


            /*Original code*/
            //for (var i = 0; i < Items.Count; i++)
            //{
            //    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            //    {
            //        if (Items[i].Quality > 0)
            //        {
            //            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            //            {
            //                Items[i].Quality = Items[i].Quality - 1;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (Items[i].Quality < 50)
            //        {
            //            Items[i].Quality = Items[i].Quality + 1;

            //            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            //            {
            //                if (Items[i].SellIn < 11)
            //                {
            //                    if (Items[i].Quality < 50)
            //                    {
            //                        Items[i].Quality = Items[i].Quality + 1;
            //                    }
            //                }

            //                if (Items[i].SellIn < 6)
            //                {
            //                    if (Items[i].Quality < 50)
            //                    {
            //                        Items[i].Quality = Items[i].Quality + 1;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            //    {
            //        Items[i].SellIn = Items[i].SellIn - 1;
            //    }

            //    if (Items[i].SellIn < 0)
            //    {
            //        if (Items[i].Name != "Aged Brie")
            //        {
            //            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            //            {
            //                if (Items[i].Quality > 0)
            //                {
            //                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            //                    {
            //                        Items[i].Quality = Items[i].Quality - 1;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                Items[i].Quality = Items[i].Quality - Items[i].Quality;
            //            }
            //        }
            //        else
            //        {
            //            if (Items[i].Quality < 50)
            //            {
            //                Items[i].Quality = Items[i].Quality + 1;
            //            }
            //        }
            //    }
            //}
        }
    }
}
