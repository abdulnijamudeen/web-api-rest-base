Use AppDatabase;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User')
BEGIN
	CREATE TABLE [User] (
    Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    Username nvarchar(50) NOT NULL,
    PasswordHash nvarchar(200) NOT NULL,
    [Role] nvarchar(30)
    );
  PRINT 'User Table Created'
END