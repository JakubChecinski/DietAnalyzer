using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System.Security.Claims;

namespace DietAnalyzer.UnitTests.Extensions
{
    public static class ApiControllerExtensions
    {
        public static void MockCurrentUser(this ControllerBase controller, string userId, string userName)
        {
            var principal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId),
            }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = principal }
            };
        }

        public static void MockUrlAction(this ControllerBase controller, string mockUrl)
        {
            var mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);
            controller.Url = mockUrlHelper.Object;
            mockUrlHelper.Setup(x => x.Action(It.IsAny<UrlActionContext>())).Returns(mockUrl);
        }

    }

}
