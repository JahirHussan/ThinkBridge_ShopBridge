CREATE PROCEDURE [dbo].[GetProductByID]
@ProductID int
AS
BEGIN
	SET NOCOUNT ON
	IF(@ProductID IS NOT NULL)
	BEGIN
	IF EXISTS (SELECT ProductID FROM [dbo].Products WHERE Products.ProductID=@ProductID AND Products.IsDeleted = 0)
		BEGIN
			SELECT ProductID,Name,Description,ProductPrice,SupplierName,ImageURL FROM [dbo].Products WHERE Products.ProductID=@ProductID AND Products.IsDeleted = 0
		END		
	END
	SET NOCOUNT OFF
	RETURN 0
END