using BestellingBL.Exceptions;
using BestellingBL.Model;

namespace TestProjectModel
{
    public class UnitTestKlant
    {
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void Test_Id_Valid(int id)
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            klant.Id = id;
            Assert.Equal(id, klant.Id);
        }
        [Fact]
        public void Test_Id_Valid_Fact()
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            klant.Id = 105;
            Assert.Equal(105, klant.Id);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Test_Id_InValid(int id)
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            var ex = Assert.Throws<BestellingException>(() => klant.Id = id);
            Assert.Equal("id<0", ex.Message);
        }
        [Theory]
        [InlineData("jos@gmail.com")]
        [InlineData("jos.dewolf@gmail.com")]
        public void Test_Email_Valid(string email)
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            klant.Email = email;
            Assert.Equal(email, klant.Email);
        }
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("@gmail.com")]
        [InlineData("jos.dewolf@gmailcom")]
        [InlineData("jos@")]
        public void Test_Email_InValid(string email)
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            Assert.Throws<BestellingException>(() => klant.Email = email);
        }
        [Fact]
        public void Test_ctor_Valid()
        {
            Klant klant = new Klant(10, "Jos", "jos@gmail.com");
            Assert.Equal(10, klant.Id);
            Assert.Equal("Jos", klant.Naam);
            Assert.Equal("jos@gmail.com", klant.Email);
        }
        [Theory]
        [InlineData(0, "Jos", "jos@gmail.com")]
        [InlineData(-1, "Jos", "jos@gmail.com")]
        [InlineData(10, "", "jos@gmail.com")]
        [InlineData(10, "  ", "jos@gmail.com")]
        [InlineData(10, null, "jos@gmail.com")]
        [InlineData(10, "Jos", "@gmail.com")]
        [InlineData(10, "Jos", "jos@gmailcom")]
        [InlineData(10, "Jos", "jos@")]
        [InlineData(10, "Jos", "")]
        [InlineData(10, "Jos", "  ")]
        [InlineData(10, "Jos", null)]
        public void Test_ctor_InValid(int id, string naam, string email)
        {
            Assert.Throws<BestellingException>(() => new Klant(id, naam, email));

        }
    }
}