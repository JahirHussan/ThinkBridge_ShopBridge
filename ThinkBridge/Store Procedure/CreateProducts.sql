CREATE PROCEDURE [dbo].[CreateProducts]
	@ProductName NVARCHAR(100),
	@ProductDescription NVARCHAR(300),
	@ProductPrice MONEY,
	@SupplierName NVARCHAR(100),
	@ImageURL NVARCHAR(max),
	@ProductID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRANSACTION
		INSERT INTO [dbo].[Products]
		(	Name,
			Description,
			ProductPrice,
			SupplierName,
			ImageURL
		)
		Values
		(	@ProductName,
			@ProductDescription,
			@ProductPrice,
			@SupplierName,
			@ImageURL
		)
		IF(@@ERROR < 0) BEGIN ROLLBACK TRANSACTION; SET NOCOUNT OFF; RETURN @@ERROR; END 
		SET @ProductID = @@IDENTITY
	COMMIT TRANSACTION
	SET NOCOUNT OFF
	RETURN 0
END
	



