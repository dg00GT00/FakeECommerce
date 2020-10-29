#!/bin/bash

# wait for MSSQL server to start
threshold=30
echo "Waiting $threshold seconds until server fully initialized..."
sleep $threshold && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -i $SQLSERVER_CONFIG_PWD/setup.sql
echo "Created default setup to unit testing purposes"