namespace GildedRose
{
    public static class LegendaryItems
    {
        private static List<string> _itemNames = new List<string>();
        public static List<string> ItemNames 
        { 
            get 
            {
                if (!_itemNames.Any())
                {
                    PopulateItemNames();
                }

                return _itemNames;
            }
        }

        private static void PopulateItemNames()
        {
            //Here we should be connecting to some data storage that will contain the list of legendary item names.
            //For the purpose of the kata, and seeing as this is out of scope in any case, I will be hardcoding the values.

            var fetchedLegendaryItems = new List<string> 
            {
                "Sulfuras, Hand of Ragnaros",
                "Thunderfury, Blessed Blade of the Windseeker",
                "Enchanted Elementium Bar",
                "Eye of Sulfuras",
                "Bindings of the Windseeker",
                "Vessel of Rebirth",
                "Dormant Wind Kissed Blade",
                "Thunderfury, Blessed Blade of the Windseeker",
                "Warglaive of Azzinoth",
                "Thori'dal, the Stars' Fury",
                "Cosmic Infuser",
                "Devastation",
                "Infinity Blade",
                "Netherstrand Longbow",
                "Phaseshift Bulwark",
                "Staff of Disintegration",
                "Warp Slicer",
                "Val'anyr, Hammer of Ancient Kings",
                "Shadowmourne",
                "Fragment of Val'anyr",
                "Shattered Fragments of Val'anyr",
                "Unbound Fragments of Val'anyr",
                "Shadowfrost Shard"
            };

            _itemNames = fetchedLegendaryItems;
        }
    }
}
