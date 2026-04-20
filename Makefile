test:
	dotnet test ./Tests/Tests.csproj
run:
	dotnet run --project ./src/sync.csproj
docker-build:
	docker build -t sync-app .
docker-run:
	docker run --rm -it -v "$(PWD)/data:/app/data" -v "$(PWD)/logs:/app/logs" sync-app
