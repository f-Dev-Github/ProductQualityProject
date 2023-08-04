using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const string GenericPrdExpName = "foo";
        public const string Conjured = "Conjured Mana Cake";
        public  const string AgedBrie = "Aged Brie";
        public  const string BackStagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public  const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const int MaximumQuality = 50;
        public const int MinimumQuality = 0;
        public const int SellInFirstValue = 6;
        public const int SellInSecondValue = 11;
        IList<Item> Items;

     
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public bool  IsAgedBriePrd(Item item)
        {
            return item.Name == AgedBrie;

        }
        public bool IsBackStagePassesPrd(Item item)
        {
            return item.Name == BackStagePasses;

        }
        public bool IsSulfurasPrd(Item item)
        {
            return item.Name == Sulfuras;

        }
        public bool IsConjuredPrd(Item item)
        {
            return item.Name == Conjured;

        }
        public bool IsGenericPrd(Item item)
        {
           if ((!IsSulfurasPrd(item))&& (!IsBackStagePassesPrd(item))&& (!IsAgedBriePrd(item)) && (!IsConjuredPrd(item)))
            {
                return true;
            }
            return false;

        }
        public void ManageGenericPrd(Item item)
        {
            if (IsGenericPrd(item))
            {
                item.SellIn--;
                item.Quality = item.SellIn > 0 ? item.Quality - 1 : item.Quality - 2;
                if (item.Quality < 0) item.Quality = MinimumQuality;
            }
        }
        public void ManageBackStagePassesPrd(Item item)
        {
            if (IsBackStagePassesPrd(item)) { 
                item.SellIn--;
                item.Quality++;
            if (item.SellIn < SellInSecondValue) item.Quality++;
            if (item.SellIn < SellInFirstValue) item.Quality++;
            if (item.SellIn <= 0) item.Quality = MinimumQuality;
            if (item.Quality > 50) item.Quality = MaximumQuality;
            }
        }
        public void ManageSulfurasPrd(Item item)
        {
            if (IsSulfurasPrd(item)) { 
                item.SellIn--;
            }

        }
        public void ManageAgedBriePrd(Item item)
        {
            if (IsAgedBriePrd(item)) {
            item.SellIn--;
            item.Quality = (item.SellIn > 0) ? item.Quality + 1 : item.Quality + 2;
            if (item.Quality>50)
                item.Quality = MaximumQuality;
            }
        }
        public void ManageConjuredPrd(Item item)
        {
            if (IsConjuredPrd(item))
            {
                item.SellIn--;
                item.Quality = (item.SellIn > 0) ? item.Quality -2 : item.Quality - 4;
                if (item.Quality < 0)
                    item.Quality = MinimumQuality;
            }
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                  ManageGenericPrd(item);
               
                 ManageBackStagePassesPrd(item);

                 ManageSulfurasPrd(item);

                 ManageAgedBriePrd(item);
                 ManageConjuredPrd(item);



            }
        }
    }
}





