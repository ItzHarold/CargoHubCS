# Cargo Hub

A C# project for Software Construction made by Jurwin, Harold, Charlotte and Daniël.

Scrum Master: Daniël

## Backend

The "Backend" project has three (3) main directories.
- Controllers
- Features
- Infrastructure

In `Controllers/` all the controllers will be put for this project.
In `Features/` you should make an independent directory for each separate model with it's related service.
So as an example:

```
Controllers/
- ItemsController.cs
Features/
- Items/
  - Item.cs
  - ItemsService.cs
- AnotherFeature/
  - Something.cs
  - SomethingService.cs
```

And the `Infrastructure/` directory should be used for all shared logic such as:
- Databases
- Middleware
- Authentication
- Authorization

### Solution

In the solution you will find various properties such as:
```
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
<EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
<AnalysisLevel>latest-recommended</AnalysisLevel>
```
Their intention should be clear but these are here to force in the direction of good and consistent code.
The code styles can be found in `.editorconfig`. This is taken from the .NET runtime as a template.
If anybody feels like the styles enforced should be changed then this can be discussed during a meeting.
You can also automatically format your code by using `dotnet format`. And if you'd like to check manually if anything needs testing you can use `dotnet format --verify-no-changes`.

## Backend.UnitTests

The tests can be run using `dotnet test`.

The `Systems/` directory contains each layer we would like to test which is in this case:
- Controllers
- Services

Repository does not fall under this category because this is automatically handled by the DI system at app startup.
To make a full test for a specific domain (like items) you should test both the controller (ItemsController.cs) and the service (ItemsService.cs).

```
Systems/
- Controllers/
  - TestItemsController.cs
- Services/
  - TestItemsService.cs
```

## Workflows

The only workflow we currently has is the `dotnet.yml` workflow. This workflow will:
1. Restore
2. Format
3. Build
4. Test

And this is done on the VPS of our DataLab as seen by the usage of:
```yml
runs-on: self-hosted
```
