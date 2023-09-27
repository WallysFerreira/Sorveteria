FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /source
COPY . .
RUN dotnet publish -c release -o /app 

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runner
WORKDIR /app
COPY --from=builder /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Produtos.dll"]