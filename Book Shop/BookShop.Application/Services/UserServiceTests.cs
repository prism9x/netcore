using BookShop.Application.Services;
using BookShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

public class UserServiceTests
{
    [Fact]
    public async Task CheckLogin_ValidCredentials_ReturnsTrue()
    {
        // Arrange
        var userManagerMock = new Mock<UserManager<AppUser>>();
        var signInManagerMock = new Mock<SignInManager<AppUser>>();

        // Mocking the FindByNameAsync method to return a user
        userManagerMock.Setup(m => m.FindByNameAsync(It.IsAny<string>()))
                        .ReturnsAsync(new AppUser { UserName = "Admin" });

        // Mocking the PasswordSignInAsync method to return success
        signInManagerMock.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), false, false))
                         .ReturnsAsync(SignInResult.Success);

        var userService = new UserService(userManagerMock.Object, signInManagerMock.Object);

        // Act
        var result = await userService.CheckLogin("Admin", "ShopBook@123");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CheckLogin_InvalidCredentials_ReturnsFalse()
    {
        // Arrange
        var userManagerMock = new Mock<UserManager<AppUser>>();
        var signInManagerMock = new Mock<SignInManager<AppUser>>();

        // Mocking the FindByNameAsync method to return null (user not found)
        userManagerMock.Setup(m => m.FindByNameAsync(It.IsAny<string>()))
                        .ReturnsAsync((AppUser)null);

        // Mocking the PasswordSignInAsync method to return failure
        signInManagerMock.Setup(m => m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), false, false))
                         .ReturnsAsync(SignInResult.Failed);

        var userService = new UserService(userManagerMock.Object, signInManagerMock.Object);

        // Act
        var result = await userService.CheckLogin("nonexistentuser", "wrongpassword");

        // Assert
        Assert.False(result);
    }
}
