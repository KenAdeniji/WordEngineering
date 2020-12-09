SqlMetal /server:(local) /database:NorthWind /views /functions /sprocs /code:LinkToSqlNorthWind.cs /language:C# /namespace:NorthwindMapping /context:LinkToSqlNorthWind
csc DynamicQueryableStub.cs DynamicQueryable.cs LinkToSqlNorthWind.cs ObjectDumper.cs
