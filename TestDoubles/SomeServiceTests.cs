using Moq;
using Services;
using ServiceTests.TestDoubles.UserService;

namespace ServiceTests
{

    public class SomeServiceTests
    {
        // DUMMY

        [Fact]
        public void SomeOtherMethod_ShouldNotThrow_WhenValidParameters()
        {
            // Arrange
            var userServiceDummy = new UserServiceDummy();
            var someService = new SomeService(userServiceDummy);

            // Act
            var exception = Record.Exception(someService.SomeOtherMethod);

            // Assert
            Assert.Null(exception);
        }

        // STUB

        [Fact]
        public void SomeMethod_ShouldReturnTrue_WhenValidParameters()
        {
            // Arrange
            var userServiceStub = new UserServiceStub();
            var someService = new SomeService(userServiceStub);

            // Act
            var result = someService.SomeMethod("testUser");

            // Assert
            Assert.True(result);
        }

        // SPY

        [Fact]
        public void SomeMethod_ShouldCallAddUserMethodWithCorrectParameters()
        {
            // Arrange
            var testUser = "testUser";
            var userServiceSpy = new UserServiceSpy();
            var someService = new SomeService(userServiceSpy);

            // Act
            someService.SomeMethod(testUser);

            // Assert
            Assert.True(userServiceSpy.Called);
            Assert.Equal(testUser, userServiceSpy.CallParameters);
        }

        // MOCKS

        [Fact]
        public void SomeMethod_ShouldCallAddUserMethodOnlyOnceWithCorrectParameters()
        {
            // Arrange
            var testUser = "testUser";
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AddUser(It.IsAny<string>())).Returns(false);

            var someService = new SomeService(userServiceMock.Object);

            // Act
            var result = someService.SomeMethod(testUser);

            // Assert
            Assert.False(result);
            userServiceMock.Verify(userServiceMock => userServiceMock.AddUser(testUser), Times.Once);
        }

        // FAKES

        [Fact]
        public void YetAnotherMethod_ShouldReturn0_WhenUserDoesNotExist()
        {
            // Arrange
            var testUser = "testUser";
            var userServiceFake = new UserServiceFake();
            var someService = new SomeService(userServiceFake);

            // Act
            var result = someService.YetAnotherMethod(testUser);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void YetAnotherMethod_ShouldReturn100_WhenUserExists()
        {
            // Arrange
            var testUser = "testUser";
            var userServiceFake = new UserServiceFake();
            var someService = new SomeService(userServiceFake);

            // Act
            someService.SomeMethod(testUser);
            var result = someService.YetAnotherMethod(testUser);

            // Assert
            Assert.Equal(100, result);
        }
    }
}