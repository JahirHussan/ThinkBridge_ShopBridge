CREATE PROCEDURE [dbo].[CheckProductName]
@ProductName NVARCHAR(100)
AS
BEGIN
	DECLARE @RowExists AS int
	SET @RowExists = (SELECT COUNT(*) FROM [dbo].[Products] WHERE Products.Name = @ProductName)
	IF (@RowExists = 0) BEGIN RETURN 0; END ELSE BEGIN RETURN 1 END;
END