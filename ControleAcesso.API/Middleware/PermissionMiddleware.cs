using System.IdentityModel.Tokens.Jwt;
using ControleAcesso.Application.Interfaces;

namespace ControleAcesso.API.Middleware
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        public PermissionMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var allowedRoutes = new List<string>
            {
                "/swagger",
                "/api/User/Login",
                "/api/User/Register",
                "/api/Health"
            };
            var path = context.Request.Path.Value;
            if (allowedRoutes.Any(allowedRoute => path.StartsWith(allowedRoute)))
            {
                await _next(context);
                return;
            }
            string controller = context.Request.RouteValues["controller"]?.ToString() + "Controller";
            string action = context.Request.RouteValues["action"]?.ToString();
            string token = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(token))
            {
                string jwtToken = token.Substring(7);
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;
                if (securityToken != null)
                {
                    string userId = securityToken.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var methodService = scope.ServiceProvider.GetRequiredService<IMethodService>();
                            bool hasPermission = await methodService.GetPermissionMethodByUserId(long.Parse(userId), controller, action);
                            if (hasPermission)
                            {
                                await _next(context);
                                return;
                            }
                        }
                    }
                }
            }
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }
    }
}
