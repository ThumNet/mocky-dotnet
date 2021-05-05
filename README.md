# Mocky dotnet

The [Mocky API](https://designer.mocky.io) implemented in dotnet.

## TODO:

- [ ] Add dapper? https://www.nuget.org/packages/Dapper/
- [x] Docker build for Raspberry Pi3
- [ ] Docker scan https://www.thorsten-hans.com/how-to-build-smaller-and-secure-docker-images-for-net5/
- [x] Remove async - https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/async
- [ ] When db empty, stats fails DBNull (might be fixed with dapper)

## Sample API calls

See [demo.http](sample/demo.http)

## Docker

docker build . -t mocky-dotnet:0.0.1
docker run -it -p 8000:80 --rm mocky-dotnet:0.0.1

### Building for Raspberry Pi3b+

There is a private repo on docker.io

1. Build the image `docker build -t thumnet/dotnet:mocky-dotnet-arm32v7 -f Dockerfile.arm32v7 .`
2. Push the image `docker push thumnet/dotnet/mocky-dotnet:arm32v7`
3. Open portainer and add the container using the tag in step 2  

<!-- LICENSE -->
## License

Distributed under the Apache 2.0 License. See `LICENSE` for more information.

<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* [Mocky](https://github.com/julien-lafont/Mocky)

### Resources

- https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/bulk-insert
- https://extendsclass.com/sqlite-browser.html#
-  https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/
- https://sqliteonline.com
