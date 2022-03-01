## Instalation

You would need:

1. EntityFrameworkCore
2. EntityFrameworkCore.Design
3. EntityFrameworkCore.SqlServer
4. EntityFrameworkCore.Relations

In order to run and build your database: 
1. Create and instantiate a database catalog on the SMSS.
2. Change localhost with your Server of SQL Express

```
"ConnectionStrings": {
    "HangmanEntities": "Server=localhost;Database=HangmanCatalog;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```

## Useful Commands

**Run command:**

On the root folder solution:

```dotnet ef migrations add Initial -p Hangman.Data/ -s Hangman.Web ```

-p : project reference
-s : source reference (connection string used or context application)

**Then you can impact your changes on the db with:**

```dotnet ef database update -p Hangman.Data/ -s Hangman.Web ```

## Now on

You will need whever you make a change on the Data project, reference this change with a new migration.

#### In order to do that you have to:

1. Run another migration like:
```dotnet ef migrations add AChangeInsideUsers -p Hangman.Data/ -s Hangman.Web ```

2. Run an update over our database:
```dotnet ef database update -p Hangman.Data/ -s Hangman.Web ```
