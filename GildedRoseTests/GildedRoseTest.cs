using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        public Item CreateAndUpdateItem(string name,int sellIn,int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items[0];


        }
    
        #region Test_GenericPrds
        [Fact]
        public void TestGenericProduct_SellInAndQualityReduced()
        {
            Item item = CreateAndUpdateItem(GildedRose.GenericPrdExpName, 4,3);

            Assert.Equal(3,item.SellIn);
            Assert.Equal(2, item.Quality);
        }
        [Fact]
        public void TestGenericPrdOutOfDate_QualityDecreaseTwice()
        {
            Item item = CreateAndUpdateItem(GildedRose.GenericPrdExpName, 0, 5);

            Assert.Equal(3, item.Quality);
        }
        [Fact]
        public void TestGenericPrd_QualityNotNegative()
        {
            Item item = CreateAndUpdateItem(GildedRose.GenericPrdExpName, 3, 0);

            Assert.Equal(0, item.Quality);
        }
        [Fact]
        public void TestGenericPrdOutOfDate_QualityNotNegative()
        {
            Item item = CreateAndUpdateItem("foo", 0, 0);

            Assert.Equal(0, item.Quality);
        }
        #endregion
        #region Test_AgedBriePrds

        [Fact]
        public void TestAgedBrie_QualityIncrease()
        {
            Item item = CreateAndUpdateItem(GildedRose.AgedBrie, 3, 4);
            Assert.Equal(5, item.Quality);
        }
        [Fact]
        public void TestAgedBrie_QualityNotSuperiorTo50()
        {
            Item item = CreateAndUpdateItem(GildedRose.AgedBrie, 3, 50);
            Assert.Equal(50, item.Quality);
        }
        [Fact]
        public void TestAgedBrieOutOfDate_QualityIncreaseTwice()
        {
            Item item = CreateAndUpdateItem(GildedRose.AgedBrie, 0, 3);
            Assert.Equal(5, item.Quality);
        }
        [Fact]
        public void TestAgedBrieOutOfDate_QualityNotSuperiorTo50()
        {
            Item item = CreateAndUpdateItem(GildedRose.AgedBrie, 0, 49);
            Assert.Equal(50, item.Quality);
        }
        #endregion

        #region Test_SulfurasPrds
        [Fact]
        public void TestSulfurasPrd_QualityIsConstant()
        {
            Item item = CreateAndUpdateItem(GildedRose.Sulfuras, 5, 80);
            Assert.Equal(80, item.Quality);
        }
        [Fact]
        public void TestSulfurasPrdOutOfDate_QualityIsConstant()
        {
            Item item = CreateAndUpdateItem(GildedRose.Sulfuras, 0, 80);
            Assert.Equal(80, item.Quality);
        }
        #endregion
        #region Test_BackstagePrds
        [Fact]
        public void TestBackstagePrd_QualityIncrease()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 25, 7);
            Assert.Equal(8, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdSellInIsTenOrLess_QualityIncreaseTwice()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 10, 7);
            Assert.Equal(9, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdSellInIsFiveOrLess_QualityIncreaseBy3()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 5, 7);
            Assert.Equal(10, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdOutOfDate_QualityEqualsZero()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 0, 5);
            Assert.Equal(0, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdSellInMoreThanTen_QualityNotSuperior50()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 40, 49);
            Assert.Equal(50, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdSellInIsTenOrLess_QualityNotSuperior50()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 10, 49);
            Assert.Equal(50, item.Quality);
        }
        [Fact]
        public void TestBackstagePrdSellInIsFiveOrLess_QualityNotSuperior50()
        {
            Item item = CreateAndUpdateItem(GildedRose.BackStagePasses, 5, 49);
            Assert.Equal(50, item.Quality);
        }
        #endregion
    }
}
