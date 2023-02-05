# EF Core reproductions

https://github.com/dotnet/efcore/issues/30197

## Setup

- Start a MySQL container: `docker run --name efcore-repros -p 3306:3306 -e MYSQL_ROOT_PASSWORD=secret -e MYSQL_DATABASE=efcore_repros -d mysql:latest`
- Run `dotnet ef dbcontext script` and execute the SQL.

## Reproduction

- Run with `dotnet run`.
- Load http://localhost:5234.
- See exception `System.InvalidCastException: Invalid cast from 'System.String' to 'Api.ArticleTitle'`.
- Expected: Allow comparison with the underlying `string` type.
- The entrypoint is in Program.cs L20.
- The value object (`ArticleTitle`) is created using the [Vogen](https://github.com/SteveDunn/Vogen/) library.
- There is a second custom-made value object (`ArticleTitle2.cs`) for testing without Vogen.