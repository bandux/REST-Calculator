using CalculatorApp.Services;

// This file contains the implementation of a custom middleware for handling JWT authentication in the CalculatorApp API. 
// The middleware is responsible for extracting and validating JWT tokens from incoming HTTP requests, 
// and attaching the authenticated user’s information (claims) to the HTTP context.

namespace CalculatorApp.Middlewares
{ /// <summary>
  /// Middleware for handling JWT authentication.
  /// This middleware intercepts incoming HTTP requests, checks for a JWT token in the Authorization header,
  /// validates the token, and sets the authenticated user's claims in the HttpContext if the token is valid.
  /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && jwtService.ValidateToken(token))
            {
                var principal = jwtService.GetPrincipalFromToken(token);
                context.User = principal;
            }

            await _next(context);
        }
    }
}
