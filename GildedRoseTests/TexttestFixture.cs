﻿
using GildedRoseKata;

using System;
using System.Collections.Generic;

namespace GildedRoseTests
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = GildedRose.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = GildedRose.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = GildedRose.Sulfuras, SellIn = -1, Quality = 80},
                new Item
                {
                    Name =  GildedRose.BackStagePasses,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = GildedRose.BackStagePasses,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = GildedRose.BackStagePasses,
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = GildedRose.Conjured, SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            int days = 31;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i < days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
