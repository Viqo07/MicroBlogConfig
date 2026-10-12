# MicroBlogConfig — Configuration & Options

## Overview

This project demonstrates how to use `appsettings.json` and the Options pattern in an ASP.NET Core Razor Pages application.

The application uses configuration settings to control the site name and whether the comment form is displayed.

## Configuration Settings

The `SiteOptions` class contains two properties:

- `SiteName`: Sets the website name displayed in the navigation bar and page title.
- `EnableComments`: Controls whether the Leave Comment form appears on the post Details page.

### appsettings.json

The default configuration sets the site name to `My Micro Blog` and disables comments.

```json
{
  "SiteOptions": {
    "SiteName": "My Micro Blog",
    "EnableComments": false
  }
}
```

### appsettings.Development.json

The Development configuration overrides `EnableComments` to `true`, allowing the comment form to appear during development.

```json
{
  "SiteOptions": {
    "EnableComments": true
  }
}
```

## Options Pattern

In `Program.cs`, the application binds the `SiteOptions` class to the `SiteOptions` configuration section using `builder.Services.Configure<SiteOptions>()`.

The shared layout uses the configured `SiteName` to display the website name. The Details page checks `EnableComments` before displaying the comment form.

## Testing Both Environments

### Development Environment

Run the following commands in PowerShell:

```powershell
$env:ASPNETCORE_ENVIRONMENT = "Development"
dotnet run --no-launch-profile
```

In Development mode, the Leave Comment form is visible on the post Details page.

Screenshot: `Development.png`

### Production Environment

Stop the application with `Ctrl + C`, then run:

```powershell
$env:ASPNETCORE_ENVIRONMENT = "Production"
dotnet run --no-launch-profile
```

In Production mode, the Leave Comment form is hidden because the default configuration sets `EnableComments` to `false`.

Screenshot: `Production.png`

## Technologies Used

- C#
- ASP.NET Core Razor Pages
- .NET
- JSON configuration
- Dependency Injection
- Options pattern

## Purpose

This project demonstrates how configuration files and the Options pattern can control application behavior differently depending on the environment.