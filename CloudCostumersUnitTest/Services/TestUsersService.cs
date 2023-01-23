using CloudCostumersUnitTest.Fixtures;
using CloudCostumersUnitTest.Helpers;
using CloudCustomers.Models;
using CloudCustomers.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CloudCostumersUnitTest.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient);

            //Act
            await sut.GetAllUsers();

            //Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
                );

        }
        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient);

            //Act
            var result = await sut.GetAllUsers();

            //Assert
            result.Count.Should().Be(0);



        }
        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient);

            //Act
            var result = await sut.GetAllUsers();

            //Assert
            result.Count.Should().Be(expectedResponse.Count);



        }

    }
}
