What is the Equinox Project?
=====================

[![Build status](https://ci.appveyor.com/api/projects/status/rl2ja69994rt3ei6?svg=true)](https://ci.appveyor.com/project/EduardoPires/equinoxproject)
![.NET Core](https://github.com/EduardoPires/EquinoxProject/workflows/.NET%20Core/badge.svg)
[![License](https://img.shields.io/github/license/eduardopires/equinoxproject.svg)](LICENSE)
[![Issues open](https://img.shields.io/github/issues/eduardopires/equinoxproject.svg)](https://huboard.com/EduardoPires/EquinoxProject/)

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- ***Please check if you have installed the same runtime version (SDK) described in global.json***
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Equinox Project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

## Technologies implemented:

- ASP.NET 6.0
 - ASP.NET MVC Core 
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Entity Framework Core 6.0
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support
- .NET DevPack
- .NET DevPack.Identity

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository