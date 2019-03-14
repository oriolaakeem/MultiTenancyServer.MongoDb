FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY infusync.identity/infusync.identity.csproj infusync.identity/
COPY infusync.DataTier/infusync.DataTier.csproj infusync.DataTier/
COPY infusync.Security/infusync.Security.csproj infusync.Security/
COPY IdentityServer4.MongoDB/IdentityServer4.MongoDB.csproj IdentityServer4.MongoDB/
COPY OENT.Entities/OENT.Entities.csproj OENT.Entities/
COPY MongoDbCore/AspNetCore.Identity.MongoDbCore.csproj MongoDbCore/
COPY OryxDomainServices/OryxDomainServices.csproj OryxDomainServices/
RUN dotnet restore infusync.identity/infusync.identity.csproj
COPY . .
WORKDIR /src/infusync.identity
RUN dotnet build infusync.identity.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish infusync.identity.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "infusync.identity.dll"]
