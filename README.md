# Toasty Watches

Easily store a list of TV shows and movies you wish to watch.

## Requirements

* Search for TV shows and movies.
* Manage items in a saved Watch List (add, remove, rank).
* Mark items as watched/seen.

## Tech Stack

* Frontend
  * Blazor Server: security, simplicity, and less calls between server and client when fetching/managing items.
  * Bootstrap: clean, modern, pre-built components allowing for a nice interface without needing to *reinvent the wheel*.
* Backend
  * ASP.NET Core.
  * ASP.NET Identity.
* APIs
  * ASP.NET Core RESTful API.
  * [The Movie Database API (TMDb)](https://developer.themoviedb.org/reference).
* Database
  * SQLite: simple setup easy for prototyping. Could later migrate to SQL Server for scalability and more complex scenarios.
  * Entity Framework Core.
* Database Management
  * DB Browser for SQLite. Could later use SQL Server Management Studio (SSMS) if the database migrates to SQL Server.
* Hosting
  * IIS Express (Development): fast, easy hosting for development.
  * Azure App Service (Production).
* Source Control
  * GitHub.
* IDE
  * Visual Studio 2022.

## Architecture

* Models: Database objects.
* Repositories: Database access, CRUD operations.
* Services: Business logic and rules.
* Views: Razor Components.
