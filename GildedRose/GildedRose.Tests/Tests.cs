using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;

namespace GildedRose.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1, 19)]
    [TestCase(2, 17)]
    [TestCase(10, 1)]
    [TestCase(11, 0)]
    [TestCase(15, 0)]
    public void GivenItemAboutToPassSellIn_ShouldDecreaseQualityTwiceAsFalt(int numberOfDays, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(1)]
    [TestCase(5)]
    public void GivenItem_ShouldHaveQualityOfZeroButNotLess(int numberOfDays)
    {
        var items = new List<Item> { new Item { Name = "Goblin Sword (Trash)", SellIn = 5, Quality = 0 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(0));
    }

    [TestCase(1, 41)]
    [TestCase(5, 45)]
    [TestCase(10, 50)]
    [TestCase(12, 50)]
    public void GivenAgedBrie_ShouldIncreaseQuality(int numberOfDays, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(3, 48)]
    [TestCase(5, 50)]
    [TestCase(7, 50)]
    public void GivenItemWithValueCloseToFifty_ShouldNotExceedQualityOfFifty(int numberOfDays, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 45 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(1)]
    [TestCase(31)]
    public void GivenSulfuras_DontEverDecreaseQuality(int numberOfDays)
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(80));
        Assert.That(result.SellIn, Is.EqualTo(0));
    }

    [TestCase(1, 21)]
    [TestCase(4, 24)]
    public void GivenBackstagePass_ShouldIncreaseInQuality(int numberOfDays, int expectedQuality) 
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(11, 21)]
    [TestCase(10, 22)]
    [TestCase(8, 22)]
    [TestCase(6, 22)]
    public void GivenBackstagePassWithSellInBetweenFiveAndTen_ShouldIncreaseInQualityByTwo(int sellIn, int expectedQuality) 
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(5, 23)]
    [TestCase(3, 23)]
    [TestCase(1, 23)]
    public void GivenBackstagePassWithSellInOfLessThanFive_ShouldIncreaseInQualityByThree(int sellIn, int expectedQuality) 
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(0, 23)]
    [TestCase(-1, 0)]
    [TestCase(-5, 0)]
    public void GivenBackstagePassWithPassedSellIn_ShouldHaveQualityOfZero(int sellIn, int expectedQuality) 
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(1, 8)]
    [TestCase(3, 4)]
    [TestCase(5, 0)]
    [TestCase(7, 0)]
    public void GivenConjuredItem_ShouldDecreaseInQualityByTwo(int numberOfDays, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };

        GildedRose gildedRose = new GildedRose(items);

        for (var i = 0; i < numberOfDays; i++)
        {
            gildedRose.UpdateQuality();
        }

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(0, 18)]
    [TestCase(-1, 16)]
    [TestCase(-5, 16)]
    public void GivenConjuredItemWithPassedSellIn_ShouldDecreaseInQualityByFour(int sellIn, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = 20 } };

        GildedRose gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        var result = gildedRose.Items.FirstOrDefault();

        Assert.That(result.Quality, Is.EqualTo(expectedQuality));
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

        foreach (var i in result)
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
                        Assert.That(i.Quality, Is.EqualTo(4));
                        Assert.That(i.SellIn, Is.EqualTo(2));
                        break;
                    }
            }

        };
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
			new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        GildedRose gildedRose = new GildedRose(items);
        for (var i = 0; i < 31; i++)
        {
            gildedRose.UpdateQuality();
        }

        Assert.That(gildedRose.Items.Any(i => i.Quality < 0 ), Is.False);
        Assert.That(gildedRose.Items.Any(i => i.Quality > 50 && !i.Name.StartsWith("Sulfuras") ), Is.False);
        Assert.That(gildedRose.Items.First(i => i.Name.StartsWith("Sulfuras") ).Quality, Is.EqualTo(80));
        Assert.That(gildedRose.Items.First(i => i.Name.StartsWith("Sulfuras") ).SellIn, Is.EqualTo(0));
        Assert.That(gildedRose.Items.First(i => i.Name == "Aged Brie").Quality, Is.EqualTo(31));
        Assert.That(gildedRose.Items.Any(i => i.Name.StartsWith("Backstage passes") && i.Quality != 0), Is.False);
        Assert.That(gildedRose.Items.Any(i => i.Name.StartsWith("Conjured") && i.Quality != 0), Is.False);
    }
}