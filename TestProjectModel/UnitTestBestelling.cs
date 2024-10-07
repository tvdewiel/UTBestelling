using BestellingBL.Exceptions;
using BestellingBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectModel
{
    public class UnitTestBestelling
    {
        private Product productA=new Product(10,"AAA",10);
        private Product productB = new Product(10, "BBB", 12);
        private Product productC = new Product(10, "CCC", 15);
        private Klant klantA = new Klant(109, "Jos", "jos@gmail.com");
        
        [Fact]
        public void Test_Prijs()
        {
            Bestelling bestelling = new Bestelling(10, klantA);
            bestelling.VoegProductToe(productA, 2);
            bestelling.VoegProductToe(productB, 1);
            bestelling.VoegProductToe(productC, 3);
            Assert.Equal(77, bestelling.Prijs());
        }
        [Fact]
        public void Test_VoegProductToe_Valid()
        {
            Bestelling bestelling = new Bestelling(10, klantA);
            bestelling.VoegProductToe(productA, 2);
            bestelling.VoegProductToe(productB, 1);
            Assert.Equal(2,bestelling.Producten().Count());
            Assert.Contains((productA,2),bestelling.Producten());
            Assert.Contains((productB, 1), bestelling.Producten());
            //verhoog aantal van A
            bestelling.VoegProductToe(productA, 3);
            Assert.Equal(2, bestelling.Producten().Count());
            Assert.Contains((productA, 5), bestelling.Producten());
            Assert.Contains((productB, 1), bestelling.Producten());
        }
        [Fact]
        public void Test_VoegProductToe_InValid()
        {
            //maak eerst valid bestelling
            Bestelling bestelling = new Bestelling(10, klantA);
            bestelling.VoegProductToe(productA, 2);
            bestelling.VoegProductToe(productB, 1);
            Assert.Equal(2, bestelling.Producten().Count());
            Assert.Contains((productA, 2), bestelling.Producten());
            Assert.Contains((productB, 1), bestelling.Producten());
            //test verkeerde invoer
            Assert.Throws<BestellingException>(() => bestelling.VoegProductToe(productA, 0));
            Assert.Throws<BestellingException>(() => bestelling.VoegProductToe(productA, -1));
            Assert.Throws<BestellingException>(() => bestelling.VoegProductToe(null, 10));
            //Assert.Equal(2, bestelling.Producten().Count());
            //Assert.Contains((productA, 5), bestelling.Producten());
            //Assert.Contains((productB, 1), bestelling.Producten());
        }
    }
}
