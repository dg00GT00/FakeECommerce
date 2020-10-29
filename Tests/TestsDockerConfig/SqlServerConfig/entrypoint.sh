#!/bin/bash

# Start the script to create the DB and user
$SQLSERVER_CONFIG_PWD/configure-db.sh &

# Start SQL Server
# The command that starts the server should be at the very end of this entrypoint
/opt/mssql/bin/sqlservr
