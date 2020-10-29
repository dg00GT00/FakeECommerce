-- Creates login, user, schema and database for unit testing purpose
-- The order of queries are important 
CREATE LOGIN TestsLogin WITH PASSWORD = 'Test12345_';
GO
GRANT ALTER ANY DATABASE TO TestsLogin;
GO
CREATE DATABASE TestsDB;
GO
USE TestsDB;
GO
CREATE USER TestsUser FOR LOGIN TestsLogin
    WITH DEFAULT_SCHEMA = Tests;
GO
CREATE SCHEMA Tests;
GO
GRANT CONTROL ON SCHEMA::Tests TO TestsUser;
GO