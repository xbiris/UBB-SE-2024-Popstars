using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;
using Xunit;

namespace ISS_Wildcats.Backend.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void TestUserClass()
        {
            // arrange
            string connectionString = "Data Source=DESKTOP-LDJ0KI4\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";
            int idUser1 = 1;
            string nameUser1 = "John Doe";
            string emailUser1 = "johndoe@example.com";
            DateTime bday = new DateTime(1980, 1, 1);
            string passwordUser1 = "password123";

            // act
            var user1 = new User(connectionString, idUser1);
            var user2 = new User();

            // assert
            Assert.NotNull(user1);
            Assert.NotNull(user2);
            Assert.NotEqual(user2, user1);
            Assert.Equal(passwordUser1, user1.Password);
            Assert.Equal(bday, user1.BirthDate);
            Assert.Equal(emailUser1, user1.Email);
            Assert.Equal(nameUser1, user1.Name);
            Assert.Equal(idUser1, user1.UserID);
        }
    }
}
