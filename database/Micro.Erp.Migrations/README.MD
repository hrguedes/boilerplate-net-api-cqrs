```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@Developer123"  -p 1433:1433  --name DevSQLSERVER --hostname sqlpreview -d mcr.microsoft.com/mssql/server:latest
```

