CREATE PROCEDURE [dbo].[Login]
 @Email NVARCHAR(100), @Password NVARCHAR(50)

	AS
	BEGIN
	  SELECT Email, [Password] FROM dbo.RegisterUserTable WHERE Email = @Email AND [Password] = @Password;
	END