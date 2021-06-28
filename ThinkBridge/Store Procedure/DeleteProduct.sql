CREATE PROCEDURE [dbo].[DeleteProduct]
@ProductID int
AS
BEGIN
	DECLARE @RowExists AS int
	SET @RowExists = (SELECT COUNT(*) FROM [dbo].[Products] WHERE Products.IsDeleted = 0 AND Products.ProductID = @ProductID)
	IF (@RowExists = 0) BEGIN RETURN 0; END

	UPDATE [dbo].[Products]
	SET    IsDeleted = 1
	WHERE  ProductID = @ProductID

	RETURN @@ROWCOUNT
END