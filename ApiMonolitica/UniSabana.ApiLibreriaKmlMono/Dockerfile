FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
LABEL stage=builder

WORKDIR /backend
COPY . .


RUN dotnet restore "UniSabana.ApiLibreriaKmlMono.csproj"
RUN dotnet publish "UniSabana.ApiLibreriaKmlMono.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0


ENV ASPNETCORE_URLS=http://+:8082
ENV TZ=America/Bogota
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8082
EXPOSE 443
ENTRYPOINT ["dotnet", "UniSabana.ApiLibreriaKmlMono.dll"]

