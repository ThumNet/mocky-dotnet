# Mocky dotnet

The [mocky](https://designer.mocky.io) API implemented in dotnet.


### Resources

https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/bulk-insert
https://extendsclass.com/sqlite-browser.html#
https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/

https://sqliteonline.com

## TODO:

- [ ] Add dapper? https://www.nuget.org/packages/Dapper/
- [ ] Docker? https://www.thorsten-hans.com/how-to-build-smaller-and-secure-docker-images-for-net5/
- [x] Remove async - https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/async
- [ ] When db empty, stats fails DBNull (might be fixed with dapper)
{
  "name": "first-item",
  "content": "this is a test",
  "contentType": "text/plain",
  "status": 200,
  "charset": "utf-8",
  "headers": {
    "additionalProp1": "string",
    "additionalProp2": "string",
    "additionalProp3": "string"
  },
  "secret": "my-big-secret",
  "expiration": 1
}