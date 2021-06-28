CREATE TABLE [dbo].[Products]
(
	[ProductID] int Identity(1,1) Not Null,
	[Name] Nvarchar(100) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [ProductPrice] MONEY NOT NULL, 
    [SupplierName] NVARCHAR(100) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [ImageURL] NVARCHAR(MAX) NULL 
)
