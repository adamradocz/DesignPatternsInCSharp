# Unit of Work Pattern

A Unit of Work keeps track of everything you do during a business transaction that can affect the database. When you're done, it figures out everything that needs to be done to alter the database as a result of your work.

In the book _Patterns of Enterprise Application Architecture_, Martin Fowler describes as follows:

> Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
