namespace ApprovedPolicyInfoSkillsEval.Middleware
{
    public class AccessLogMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var policyNumber = context.Request.RouteValues["policyNumber"];

            if (policyNumber != null)
            {
                Console.WriteLine($"Approved Policy Information Request for Policy Number: {policyNumber}");
            }

            await _next(context);
        }
    }
}
