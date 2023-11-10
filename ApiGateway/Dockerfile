FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
LABEL stage=builder

WORKDIR /backend
COPY . .


RUN dotnet restore "ApiGateway.csproj"
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0


ENV ASPNETCORE_URLS=http://+:8080
ENV TZ=America/Bogota
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiGateway.dll"]

#ADD PERMISES
RUN chgrp -R 0 /app/ApiGateways /app && \
chmod -R g=u /app/ApiGateways /app

