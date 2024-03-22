# Recipe Management System: .NET Project

## Main API Project

**Clean Architecture Implementation**
- **Task:** Implement the Clean architecture pattern including:
  - Separate layers for Presentation, Application, Domain, and Infrastructure.
  - Use MediatR pattern for handling requests.
  - Implement CQRS pattern for separating read and write operations.
  - Use FluentValidation for automatic validation of requests.

**Database Setup using Migrations (Code First)**
- **Task:** Generate database tables with the following entities:
  - User: to store user information.
  - Recipe: to define recipe details such as title, ingredients, instructions, and category.
  - Category: to categorize recipes.
  - FavoriteRecipe: to allow users to save their favorite recipes.
  - Ensure proper relationships between entities: 1:1, 1:N, N:N.

**Command and Query Creation**
- **Task:** Create the following commands and queries:
  - CreateRecipeCommand: to allow users to create new recipes.
  - SaveRecipeToFavoriteCommand: to save a recipe to the user's favorites.
  - GetRecipeByIdQuery: to retrieve recipe details by ID.
  - GetAllRecipesQuery: to retrieve all recipes.
  - GetFavoriteRecipesByUserIdQuery: to retrieve favorite recipes of a user.

**Authorization and Authentication**
- **Task:** Implement at least two types of authorization schemes:
  - JWT-based authorization for API endpoints.
  - API Key-based authorization for Webhook endpoints.

**Webhook Creation**
- **Task:** Create a webhook to notify external systems when a new recipe is added.

## SDK Project
### Points: 8

**Utilize Refit for API Calls to Main API Project**
- **Task:** Use Refit library to create a client for making HTTP requests to the Main API project.

**SDK Library Deployment on nuget.org**
- **Task:** Package the SDK library and deploy it on nuget.org for easy integration.

## Test SDK API Project
### Points: 6

**Utilize Own SDK Project**
- **Task:** Use the SDK project to test API integration for creating recipes, saving favorite recipes, and retrieving recipes.

**Installation via NuGet Manager**
- **Task:** Install the SDK package via NuGet Manager in a separate test project to verify functionality.
