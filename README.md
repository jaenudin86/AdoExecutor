AdoExecutor
===========

What is it?
-----------
AdoExecutor is a helper for execute sql query. It is based on C# ADO.

It's quite similar to <a href="https://github.com/StackExchange/dapper-dot-net">Dapper</a> but it based on a few rules.
* Be easy to use
* All infrastructure should be flexibility, easy to extend
* Use interfaces, do not use extensions - It's hard to mock in tests
* Do not modify user sql query

How it works?
-------------

It's really simple, in base scenarios you shoud use SqlAdoExecutorQueryFactory and invoke one of two methods 
* Execute - for insert, update, delete data, execute stored procedures etc, 
* Select - for select data

How can i use it?
-----------------
The most important interface is IAdoExecutorQuery
```csharp
public interface IAdoExecutorQuery
{
  IDbConnection Connection { get; }
  int Execute(string query, object parameters = null);
  T Select<T>(string query, object parameters = null);
}
``` 
Connection - You can manipulate connection, begin/end transactions etc.
Execute - execute query
Select - execute query and map result to specified generic parameter

What type of parameters are supported?
* Any user declared class or anonymous type - it all public, instances properties will be converter to parameters
* DataTable - but with single row, columns in dataTable and query parameters must have same names
* IDictionary<string, object> - key is parameter name, value is parameter value
* Array of primitive types (string, int, guid, decimal etc.) - parameter name will be array index number
* SpecifiedParameter or Array of SpecifiedParameter - a AdoExecutor class, use for declare input/output parameter or most difficult scenarios who require control with create sql parameter

What type of result (generic) are supported?
* DataSet - it can be use with multiple select statement in single query
* DataTable
* Dynamic type or Array of Dynamic type
* Primitive type or Array of Primitive type
* User class or struct or Array of user class or struct - the result colums must have exacly same name and type with object properties

Examples?
---------

Select data and map result to Account class
```csharp
public class Account
{
  public int Id { get; set; }
  public string Login { get; set; }
  public string PasswordHash { get; set; }
  public bool? IsBlocked { get; set; }
  public DateTime? Created { get; set; }
  public int FailedLoginCount { get; set; }
}

private static void Main(string[] args)
{
  var adoExecutorQueryFactory = new SqlAdoExecutorQueryFactory("test");
  IAdoExecutorQuery query = adoExecutorQueryFactory.CreateQuery();

  var queryText = @"select Id, Login, PasswordHash, IsBlocked, Created, FailedLoginCount 
                   from dbo.Account
                   where id = @id";

  var queryParameter = new {Id = 5};
  var result = query.Select<Account>(queryText, queryParameter);
}
```

Want get list of all Account? Even simpler
```csharp
ar adoExecutorQueryFactory = new SqlAdoExecutorQueryFactory("test");
IAdoExecutorQuery query = adoExecutorQueryFactory.CreateQuery();

var queryText = @"select Id, Login, PasswordHash, IsBlocked, Created, FailedLoginCount from dbo.Account";
var result = query.Select<Account[]>(queryText); 
```
