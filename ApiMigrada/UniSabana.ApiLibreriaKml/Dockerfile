FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
LABEL stage=builder

WORKDIR /backend
COPY . .


RUN dotnet restore "UniSabana.ApiLibreriaKml.csproj"
RUN dotnet publish "UniSabana.ApiLibreriaKml.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0


ENV ASPNETCORE_URLS=http://+:8081
ENV TZ=America/Bogota
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8081
ENTRYPOINT ["dotnet", "UniSabana.ApiLibreriaKml.dll"]

