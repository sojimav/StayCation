
CREATE PROCEDURE InsertUser

    @FullName VARCHAR(100),
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.RegisterUserTable ( [FullName], [Email], [Password])
    VALUES ( @FullName, @Email, @Password)
END
