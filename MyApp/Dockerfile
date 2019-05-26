FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
USER 0
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyApi/MyApi.csproj", "MyApi/"]
RUN dotnet restore "MyApi/MyApi.csproj"
COPY . .
WORKDIR "MyApi"
RUN dotnet build "MyApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

RUN chown -R 1001:0 /app && chmod -R og+rwx /app
ENV ASPNETCORE_URLS="http://*:8080"
EXPOSE 8080

USER 1001

ENTRYPOINT ["dotnet", "MyApi.dll"]