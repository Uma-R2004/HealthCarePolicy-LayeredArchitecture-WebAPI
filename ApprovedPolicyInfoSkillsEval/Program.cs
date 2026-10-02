using ApprovedPolicyInfoSkillsEval.Middleware;
using ApprovedPolicyInfoSkillsEval.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the policy data service using scoped lifetime.
builder.Services.AddScoped<IPolicyDataService, PolicyDataService>();

var app = builder.Build();

// Enable Swagger UI. For assessment/demo purposes this is enabled in all environments.
// ✅ Environment check
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
 // Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 */

// ❗ Optional: enable in PROD only if needed
// if (app.Environment.IsProduction())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

// Custom middleware that logs the policy number before controller logic runs.
app.UseMiddleware<AccessLogMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
