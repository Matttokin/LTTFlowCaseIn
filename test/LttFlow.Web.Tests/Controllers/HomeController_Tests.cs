using System.Threading.Tasks;
using LttFlow.Models.TokenAuth;
using LttFlow.Web.Controllers;
using Shouldly;
using Xunit;

namespace LttFlow.Web.Tests.Controllers
{
    public class HomeController_Tests: LttFlowWebTestBase
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