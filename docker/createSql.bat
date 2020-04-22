echo 'https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash'
docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sqlserver  -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
