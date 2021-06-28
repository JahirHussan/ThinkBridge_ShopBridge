CREATE PROCEDURE [dbo].[UpdateProduct]
@ProductID int,
@ProductName NVARCHAR(100),
@ProductDescription NVARCHAR(300),
@ProductPrice MONEY,
@SupplierName NVARCHAR(100),
@ImageURL NVARCHAR(max)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION
	DECLARE @RowExists AS int
	SET @RowExists = (SELECT COUNT(*) FROM [dbo].[Products] WHERE Products.IsDeleted = 0 AND Products.ProductID = @ProductID)
	IF(@RowExists >0)
	BEGIN
		UPDATE [dbo].[Products]
		SET Products.Name= @ProductName,
		Products.Description= @ProductDescription,
		Products.ProductPrice = @ProductPrice,
		Products.SupplierName= @SupplierName,
		Products.ImageURL= @ImageURL
		WHERE Products.ProductID = @ProductID
	END
	COMMIT TRANSACTION
	SET NOCOUNT OFF
	RETURN 0
END
