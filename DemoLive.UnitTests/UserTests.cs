namespace DemoLive.UnitTests
{
    [TestClass]
    public class UserTests
    {
        private User _user;

        [TestInitialize]
        public void Init()
        {
            _user = new User("cdric.brasseur@gmail.com");
        }

        [TestMethod]
        public void Connect_WithNewUser_IsConnectedIsTrue()
        {
            //Console.WriteLine("Bonjour");
            // Arrange
            // Act
            _user.Connect();

            // Assert
            Assert.IsTrue(_user.IsConnected);
        }

        [TestMethod]
        [DataRow("Hello")]
        [DataRow("Coucou")]
        [DataRow("Toto")]
        [DataRow("Une chaine de caractères avec des espaces")]
        public void ReturnStringWithSomething_WithHelloAsMessage_ReturnSomethingWithHello(string message)
        {
            // Act
            var result = _user.ReturnStringWithSomething(message);

            // Assert
            // En général, on ne test pas avec une égalité les chaînes de caractères
            // On va plutôt vérifier dans ce cas la présence du message avec un Contains.
            //Assert.AreEqual("QuelqueChose + Hello", result);
            Assert.IsTrue(result.Contains(message));
        }

        [TestMethod]
        public void AddFiveToValue_WithNotConnectedUser_ThrowsException()
        {
            // Arrange
            _user.IsConnected = false;

            // Act & Assert (car exception)
            Assert.ThrowsException<Exception>(() => _user.AddFiveToValue());
        }

        [TestMethod]
        [DataRow(10, 15)]
        [DataRow(443, 448)]
        [DataRow(0, 5)]
        [DataRow(999, 1004)]
        public void AddFiveToValue_WithConnectedUserWithInitialValue_ValueIsNowExpectedValue(
            int initialValue,
            int expectedValue
        )
        {
            // Arrange
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act
            _user.AddFiveToValue();

            // Assert
            Assert.AreEqual(expectedValue, _user.Value);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-50)]
        [DataRow(-19000)]
        public void AddFiveToValue_WithConnectedUserWithNegativeInitialValue_ThrowsCannotUseNegativeNumber(int initialValue)
        {
            // Arrange
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert
            Assert.ThrowsException<CannotUseNegativeNumber>(() => _user.AddFiveToValue());
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(1234)]
        [DataRow(19000)]
        public void AddFiveToValue_WithConnectedUserWithTooHighInitialValue_ThrowsCannotUseHigherThanThousandNumber(int initialValue)
        {
            // Arrange
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert
            Assert.ThrowsException<CannotUseHigherThanThousandNumber>(() => _user.AddFiveToValue());
        }

        [TestMethod]
        public void ReturnEmail_WithNewUser_ReturnsRightEmail()
        {
            // Arrange
            var email = "autre.email@gmail.com";
            var user = new User(email);

            // Act
            var result = user.ReturnEmail();

            // Assert
            Assert.AreEqual(email, result);
        }
    }
}