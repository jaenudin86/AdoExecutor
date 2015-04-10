## Informations
Assumption of library (overlay) AdoExecutor is to assist users to query a database using ADO.NET driver.
Library is similar to [Dapper](https://github.com/StackExchange/dapper-dot-net), however while creating it i was guided by few rules:
* Extensibility - possibility of easy extending and modifying classes - all elements of subsystem are built upon interfaces and where it is possible virtual methods are used.
  * Interception - possibility to inject into query execution process. For example it is very helpful when You must add logging to all executed queries into Your application - more informations in paragraph 7.
  * Add support to own select data types - more informations in paragraph 2 and 8.
  * Add support to own input parameter types - more informations in paragraph 5 and 9.
* Testability - possibility to use mocks of data access layer (library doesn't use extensions methods).
* Easiness of use - after reading this document You should have the knowledge to configure the library and execute database query.
* Adaptable to many database engines - those that support ADO.NET driver.

## Quick start:

#### 1. Creating an instance of object to query database
If You want create instance of class supporting database queries You should use factory (implementation)
```IQueryFactory```. AdoExecutor provide default factory ```SqlQueryFactory``` that is cooperating with MS SQL database, using it You will get configured ```Query``` object.

```csharp
IQueryFactory queryFactory = new SqlQueryFactory("connectionStringAppConfigKey");
IQuery query = queryFactory.CreateQuery();
```

Most important AdoExecutor interface is ```IQuery```.

```csharp
public interface IQuery : IDisposable
{
  IDbConnection Connection { get; }
  int Execute(string query, object parameters = null, QueryOptions options = null);
  T Select<T>(string query, object parameters = null, QueryOptions options = null);
  void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
  void CommitTransaction();
  void RollbackTransaction();
}
```

> Connection is auto-open when You use ```Execute```, ```Select``` or ```BeginTransaction```. You can also invoke ```Connection.Open()```.
> For close connection use ```Dispose``` or ```Connection.Close()```.

#### 2. Selecting data
While conducting database query, that returns any dataset You should use generic method ```Select<T>``` from ```IQuery``` interface.

```csharp
string result = query.Select<string>("select name from dbo.User where id = @id", new {id = 5});
```

More informations about objects, that can be provided as parameters and about options of executing queries you can find in paragraphs 5 and 6. 

Table below contains objects types that are supported by ```Select<T>``` method.

|Supported object type|Additional informations|
|---------------------|-----------------------|
|```DataSet```|Supports many result from one query (many DataTables)|
|```DataTable```||
|```dynamic```|Supports also: ```T[], List<T>, Collection<T>, ObserableCollection<T>, IList<T>, ICollection<T>, IEnumerable<T>, ReadOnlyCollection<T>, ReadOnlyObservableCollection<T>```.|
|Custom user type|It must have public, parameterless constructor. Properties in that type must have same names as columns returned by the query (ignore case). All other properties that doesn't meet this requirements are ignored. Supports also: ```T[], List<T>, Collection<T>, ObserableCollection<T>, IList<T>, ICollection<T>, IEnumerable<T>, ReadOnlyCollection<T>, ReadOnlyObservableCollection<T>```.|
|All primitive types and nullable of primitive types|Supports also: ```T[], List<T>, Collection<T>, ObserableCollection<T>, IList<T>, ICollection<T>, IEnumerable<T>, ReadOnlyCollection<T>, ReadOnlyObservableCollection<T>```.|

#### 3. Executing query without result
While executing database query that doesn't returns any result You should use ```Execute``` method from ```IQuery``` interface.

```csharp
query.Execute("update dbo.User set name = @name where id = @id", new {name = "test", id = 5});
```

More informations about objects, that can be provided as parameters and about options of executing queries You can find in paragraphs 5 and 6. 

#### 4. Executing query in the transaction
To execute database query in transaction You should use methods from ```IQuery``` interface: ```BeginTransaction```, ```CommitTransaction```, ```RollbackTransaction```.

```csharp
query.BeginTransaction();
try
{
  query.Execute("update dbo.User set name = @name where id = @id", new {name = "test", id = 5});
  query.Execute("update dbo.User set name = @name where id = @id", new {name = "test1", id = 10});

  query.CommitTransaction();
}
catch (Exception ex)
{
  query.RollbackTransaction();
}
```

#### 5. Supported input parameters
Table below contains supported object types, that can be passed as a input parameter to ```Select<T>``` and ```Execute``` method.

|Supported object type|Additional informations|
|---------------------|-----------------------|
|```DataTable```|Columns names are mapped as input parameters names and the values from first row are mapped as a parameters values.|
|```IDictionary<string, object>```|Dictionary keys are mapped as input parameters names and dictionary values are mapped as a parameters values. The dictionary value cannot be null because the library must be able to recognise object type. The object type must be primitive.|
|```IEnumerable```|The parameters names are equal to collection indexer (@0, @1, @2 etc.) and parameters values are retrieved from enumerator. The enumerator value cannot be null because the library must be able to recognise object type. The object type must be primitive.|
|Anonymous type|Properties types must be primitive.|
|Custom user type|Properties types must be primitive.|
|```SpecifiedParameter```|Support output parameters.|

#### 6. Options of executing queries
While executing ```Select<T>``` and ```Execute``` methods You can pass optional parameter ```QueryOptions```. ```QueryOptions``` parameter allows to manipulate Timeout and CommandType values.

```csharp
query.Execute("update dbo.User set name = @name where id = @id", new {name = "test", id = 5}, QueryOptions.SetTimeout(1000));
```

## Extensibility

#### 7.Interceptors
For inject into query execution process You should implement ```IInterceptor```. The interface has specified methods, who will be invoked in times:
* ```OnEntry``` - before execution query on database
* ```OnSuccess``` - when executed query not thrown exception
* ```OnError``` - when executed query thrown exception
* ```OnExit``` - regardless of whether executed query thrown or not thrown exception

You can also use built-in helper class for logging - ```LoggerInterceptorBase```. This class prepare by self full query message (query text and list of parameters with informations about parameter name, value and type).

#### 8. Add own select data type support

#### 9. Add own input parameter type support
