FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app
COPY ./*.sln ./

COPY ./DataLayer/DataLayer.csproj ./DataLayer/DataLayer.csproj
COPY ./BusinessLayer/BusinessLayer.csproj ./BusinessLayer/BusinessLayer.csproj
COPY ./MyApi/MyApi.csproj ./MyApi/MyApi.csproj

COPY . . 

RUN dotnet restore
RUN dotnet build -c Release --no-restore

RUN dotnet publish "./MyApi/MyApi.csproj" -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Local
COPY --from=build /app/MyApi/out .
ENTRYPOINT ["dotnet", "MyApi.dll"]