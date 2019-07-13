FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ContactsCRUD/ContactsCRUD.csproj", "ContactsCRUD/"]
RUN dotnet restore "ContactsCRUD/ContactsCRUD.csproj"
COPY . .
WORKDIR "/src/ContactsCRUD"
RUN dotnet build "ContactsCRUD.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContactsCRUD.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContactsCRUD.dll"]