USE [ThinkBridge]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (1, N'iPhone', N'iPhone max ', 15000.0000, N'Apple', 0, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (2, N'Headset', N'Sony brand headset with mic', 5000.0000, N'Sony', 0, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (3, N'Redmi Note10', N'Redmi Note 10 mobile with 16 mega pixcel selfi camera', 18000.0000, N'Redmi', 0, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (4, N'Trimmer', N'Lift & Trim system', 2500.0000, N'Philips', 1, N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.myntra.com%2Ftrimmer&psig=AOvVaw1cHCY1w4kzO98dqjmhg3Qf&ust=1624995004537000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJj71qSIu_ECFQAAAAAdAAAAABAP')
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (5, N'T-Shirt', N'All size are available for white color', 500.0000, N'Allensolly', 0, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (6, N'Watch', N'Pair watch', 750.0000, N'Promise', 0, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [ProductPrice], [SupplierName], [IsDeleted], [ImageURL]) VALUES (7, N'Smart TV', N'Sony Brand 42 inch LED TV', 20000.0000, N'Amazon', 0, N'https://www.google.com/url?sa=i&url=https%3A%2F%2Fgadgets.ndtv.com%2Fmicromax-40-inch-led-full-hd-tv-40a6300-9347&psig=AOvVaw3ZeJWkBNopp0uCDSt8hRcN&ust=1624994339773000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCICHgeWFu_ECFQAAAAAdAAAAABAI')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
