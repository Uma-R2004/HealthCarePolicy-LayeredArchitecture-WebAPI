# HealthCarePolicy Layered Architecture Web API

## Overview
HealthCarePolicy is a .NET 8 ASP.NET Core Web API sample that demonstrates a layered architecture for retrieving approved healthcare policy information and validating policy-related input.

## Technology Stack
- .NET 8
- ASP.NET Core Web API
- C#
- Swagger / OpenAPI
- xUnit
- Visual Studio 2022

## Solution Structure
- Controllers / PolicyController.cs
- Middleware / AccessLogMiddleware.cs
- Models / Policy.cs
- Services / IPolicyDataService.cs
- Services / PolicyDataService.cs
- Validators / PolicyValidator.cs
- Validators / PremiumValidator.cs
- ApprovedPolicyInfoSkillsEval.Test / xUnit tests

## Main Endpoint
POST /api/Policy/ApprovedPolicyInfo/{policyNumber}

## Run and Test
1. Open the solution in Visual Studio 2022.
2. Set ApprovedPolicyInfoSkillsEval as the Startup Project.
3. Run the application.
4. Open https://localhost:49700/swagger/index.html
5. Expand POST /api/Policy/ApprovedPolicyInfo/{policyNumber}.
6. Click Try it out.
7. Enter a policy number that exists in the application data.
8. Click Execute.
9. Review the HTTP status code and response body.

## Request Flow
Client / Swagger
    -> PolicyController
    -> Validators
    -> IPolicyDataService
    -> PolicyDataService
    -> Policy Model / Data
    -> HTTP Response

AccessLogMiddleware handles cross-cutting request/response logging around the HTTP pipeline.

## Testing
Use Visual Studio Test Explorer to run the xUnit test project. The project includes validation tests such as premium validation.

## GitHub Notes
Recommended repository name:
HealthCarePolicy-LayeredArchitecture-WebAPI

Before publishing, do not commit passwords, connection strings, API keys, certificates, or sensitive healthcare/patient information.
