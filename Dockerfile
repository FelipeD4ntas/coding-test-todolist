# Use o SDK do .NET para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie os arquivos da solução para o contêiner
COPY . .

# Restaure as dependências e compile o projeto
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use a imagem do ASP.NET Runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copie os arquivos compilados para o contêiner final
COPY --from=build /app/out .

# Exponha as portas usadas pelo projeto
EXPOSE 7164

# Configuração para ouvir em todas as interfaces
ENV ASPNETCORE_URLS=http://+:7164

# Defina o comando de inicialização
ENTRYPOINT ["dotnet", "TesteDotkon.WebApi.dll"]
