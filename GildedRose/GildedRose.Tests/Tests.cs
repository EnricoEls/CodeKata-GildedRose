using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;

namespace GildedRose.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1)]
    [TestCase(31)]
    public void GivenSulfuras_DontEverDecreaseQuality(int numberOfDays)
    {
        var items = new List<Item> { new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80} };

        GildedRose gildedRose = new GildedRose(items);

        for(var i = 0; i < numberOfDays; i++) 
        {
            gildedRose.UpdateQuality();
        }        

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(80));
        Assert.That(result.SellIn, Is.EqualTo(0));
    }

    [Test]
    public void GivenItems_ShouldCalculateSingleDaysChange()
    {
        var items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    };

        GildedRose gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        var result = gildedRose.Items;

        result.ForEach(i =>
        {
            switch (i.Name)
            {
                case "+5 Dexterity Vest":
                    {
                        Assert.That(i.Quality, Is.EqualTo(19));
                        Assert.That(i.SellIn, Is.EqualTo(9));
                        break;
                    }
                case "Aged Brie":
                    {
                        Assert.That(i.Quality, Is.EqualTo(1));
                        Assert.That(i.SellIn, Is.EqualTo(1));
                        break;
                    }
                case "Elixir of the Mongoose":
                    {
                        Assert.That(i.Quality, Is.EqualTo(6));
                        Assert.That(i.SellIn, Is.EqualTo(4));
                        break;
                    }
                case "Sulfuras, Hand of Ragnaros":
                    {
                        Assert.That(i.Quality, Is.EqualTo(80));
                        Assert.That(i.SellIn, Is.EqualTo(0));
                        break;
                    }
                case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        Assert.That(i.Quality, Is.EqualTo(21));
                        Assert.That(i.SellIn, Is.EqualTo(14));
                        break;
                    }
                case "Conjured Mana Cake":
                    {
                        Assert.That(i.Quality, Is.EqualTo(5));
                        Assert.That(i.SellIn, Is.EqualTo(2));
                        break;
                    }
            }

        });
    }

    [Test]
    public void GoldenTest() 
    {
        var items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
			// this conjured item does not work properly yet
			new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        GildedRose gildedRose = new GildedRose(items);
        for (var i = 0; i < 31; i++)
        {
            gildedRose.UpdateQuality();
        }

        Assert.That(gildedRose.Items.Any(i => i.Quality < 0 ), Is.False);
        Assert.That(gildedRose.Items.Any(i => i.Quality > 50 && !i.Name.StartsWith("Sulfuras") ), Is.False);
        Assert.That(gildedRose.Items.Any(i => i.Quality == 0 && i.Name == "Aged Brie"), Is.False);
    }
}