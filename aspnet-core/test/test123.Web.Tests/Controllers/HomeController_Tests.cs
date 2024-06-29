using System.Threading.Tasks;
using test123.Models.TokenAuth;
using test123.Web.Controllers;
using Shouldly;
using Xunit;

namespace test123.Web.Tests.Controllers
{
    public class HomeController_Tests: test123WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}