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

