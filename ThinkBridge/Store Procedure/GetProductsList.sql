CREATE PROCEDURE [dbo].[GetProductsList]
AS
BEGIN
	SET NOCOUNT ON	
		SELECT ProductID,Name,Description,ProductPrice,SupplierName,ImageURL FROM [dbo].Products WHERE (Products.IsDeleted = 0)
	SET NOCOUNT OFF
	RETURN 0
END

