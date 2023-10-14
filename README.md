# user-auth.api
Install dotnet 7 sdk
Install Postgresql
dotnet add package Npgsql.EntityFrameworkCore.postgreSQL --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.12
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.11

create Folder Data in root directory
create class APiDbContext in Data and inherit its properties from DbContext
embed DbContext and connection string in program.cs

run : dotnet build to check for error and if it succeeds in build process then its to start building the models.
