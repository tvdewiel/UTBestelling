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
            var ex=Assert.Throws<BestellingException>(()=> klant.Id = id);
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
    }
}