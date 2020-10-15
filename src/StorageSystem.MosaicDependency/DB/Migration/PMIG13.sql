---- Migration script to update the productive database schema from version 13 to 14 ----

---------------------------------------------------

CREATE TABLE [Tenants](
	[ID] VARCHAR NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Description] NVARCHAR NOT NULL, 	
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [ComponentID])
);

CREATE UNIQUE INDEX [Tenants_ID_Index] ON [Tenants]([ID], [ComponentID]);

---------------------------------------------------

CREATE TABLE [StockLocations](
	[ID] VARCHAR NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Description] NVARCHAR NOT NULL, 		
	[TotalCapacity] INT NOT NULL, 
	[UsedCapacity] INT NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [ComponentID])
);

CREATE UNIQUE INDEX [StockLocations_ID_Index] ON [StockLocations]([ID], [ComponentID]);

---------------------------------------------------

CREATE TABLE [MasterArticles](
	[ID] INT NOT NULL, 	
	[TenantID] VARCHAR NOT NULL,
	[Code] NVARCHAR NOT NULL, 	
	[Name] NVARCHAR NOT NULL,	
	[DosageForm] NVARCHAR NOT NULL, 
	[PackagingUnit] NVARCHAR NOT NULL, 
	[RequiresFridge] BOOLEAN NOT NULL, 
	[MaxSubItemQuantity] INT NOT NULL,
	[StockLocationID] VARCHAR NOT NULL, 
	[MachineLocation] VARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [TenantID])
);

CREATE UNIQUE INDEX [MasterArticles_ID_Index] ON [MasterArticles]([ID], [TenantID]);
CREATE INDEX [MasterArticles_Code_Index] ON [MasterArticles]([Code]);
CREATE INDEX [MasterArticles_Name_Index] ON [MasterArticles]([Name]);
CREATE INDEX [MasterArticles_StockLocationID_Index] ON [MasterArticles]([StockLocationID]);

---------------------------------------------------

INSERT INTO [MasterArticles]([ID], 
							 [TenantID], 
							 [Code], 
							 [Name], 
							 [DosageForm], 
							 [PackagingUnit],
						     [RequiresFridge], 
							 [MaxSubItemQuantity], 
							 [StockLocationID], 
							 [MachineLocation], 
						     [LastChange])						 
SELECT [ID], 
	   '' AS TenantID, 
	   [Code], 
	   [Name], 
	   [DosageForm], 
	   [PackagingUnit],
	   [RequiresFridge], 
	   [MaxSubItemQuantity], 
	   '' AS StockLocationID, 
	   '' AS MachineLocation, 
	   [LastChange] 
FROM [Articles] 
WHERE [ComponentID] = 1 AND [IsMasterArticle] = 1;

---------------------------------------------------

CREATE TABLE [ArticleMaxSubItemQuantitys](
	[ID] NVARCHAR NOT NULL, 	
	[TenantID] VARCHAR NOT NULL,
	[MaxSubItemQuantity] INT NOT NULL,
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [TenantID])
);

CREATE UNIQUE INDEX [ArticleMaxSubItemQuantitys_ID_Index] ON [ArticleMaxSubItemQuantitys]([ID], [TenantID]);

---------------------------------------------------

INSERT OR REPLACE INTO [ArticleMaxSubItemQuantitys]([ID], 
													[TenantID], 
													[MaxSubItemQuantity],
													[LastChange])						 
SELECT [Code] AS ID, 
	   '' AS TenantID, 
	   [MaxSubItemQuantity], 
	   [LastChange] 
FROM [Articles];

---------------------------------------------------

DROP INDEX [ArticleAttributes_ID_Index];
DROP TABLE [ArticleAttributes];
DROP INDEX [PackAttributes_ID_Index];
DROP TABLE [PackAttributes];

---------------------------------------------------

ALTER TABLE [Articles] RENAME TO [Articles_Old];

DROP INDEX [Articles_ID_Index];
DROP INDEX [Articles_Code_Index];
DROP INDEX [Articles_Name_Index];

CREATE TABLE [Articles](
	[ID] INT NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Code] NVARCHAR NOT NULL, 	
	[Name] NVARCHAR NOT NULL,	
	[DosageForm] NVARCHAR NOT NULL, 
	[PackagingUnit] NVARCHAR NOT NULL, 
	[RequiresFridge] BOOLEAN NOT NULL, 
	[MaxSubItemQuantity] INT NOT NULL,
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL, 	
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	PRIMARY KEY(ID, ComponentID)
);

CREATE UNIQUE INDEX [Articles_ID_Index] ON [Articles]([ID], [ComponentID]);
CREATE INDEX [Articles_Code_Index] ON [Articles]([Code]);
CREATE INDEX [Articles_Name_Index] ON [Articles]([Name]);


INSERT INTO [Articles]([ID], 
					   [ComponentID], 
					   [Code], 
					   [Name], 
					   [DosageForm], 
					   [PackagingUnit],
					   [RequiresFridge], 
					   [MaxSubItemQuantity], 
					   [IsAvailable], 
					   [IsBlocked], 
					   [LastChange]) 						 
SELECT [ID], 
	   [ComponentID], 
	   [Code], 
	   [Name], 
	   [DosageForm], 
	   [PackagingUnit],
	   [RequiresFridge], 
	   [MaxSubItemQuantity], 
	   [IsAvailable], 
	   [IsBlocked], 
	   [LastChange] 
FROM [Articles_Old] 
WHERE [IsMasterArticle] != 1;

DROP TABLE [Articles_Old];

---------------------------------------------------

ALTER TABLE [Packs] ADD COLUMN [StockLocationID] VARCHAR NOT NULL DEFAULT '';
ALTER TABLE [Packs] ADD COLUMN [TenantID] VARCHAR NOT NULL DEFAULT '';
ALTER TABLE [Packs] ADD COLUMN [MachineLocation] VARCHAR NOT NULL DEFAULT '';

CREATE INDEX [Packs_StockLocationID_Index] ON [Packs]([StockLocationID]);
CREATE INDEX [Packs_TenantID_Index] ON [Packs]([TenantID]);
CREATE INDEX [Packs_MachineLocation_Index] ON [Packs]([MachineLocation]);

---------------------------------------------------

DROP VIEW [PackAndArticles];

CREATE VIEW [PackAndArticles] AS 
SELECT 	Packs.ID, 
		Packs.ArticleID, 
		Packs.ArticleCode,
		Packs.ComponentID,  
		Packs.BatchNumber,
		Packs.DeliveryNumber,
		Packs.ExpiryDate,
		Packs.ExternalID,
		Packs.IsInFridge,
		Packs.Shape,
		Packs.SubItemQuantity,
		Packs.ScanCode,
		Packs.StockInDate,
		Packs.Depth,
		Packs.Height,
		Packs.Width,
		Packs.StockLocationID, 
	    Packs.TenantID,
	    Packs.MachineLocation, 
		Packs.IsAvailable,
		Packs.IsBlocked,
		Packs.LastChange,
		Articles.Name,
		Articles.Code,
		Articles.DosageForm,
		Articles.PackagingUnit,
		Articles.RequiresFridge,
		Articles.MaxSubItemQuantity,
		StockLocations.Description AS StockLocationDescription,
		Tenants.Description AS TenantDescription 
FROM Packs 
LEFT JOIN Articles 
ON Packs.ArticleID=Articles.ID AND Packs.ComponentID=Articles.ComponentID 
LEFT JOIN StockLocations 
ON Packs.StockLocationID=StockLocations.ID AND Packs.ComponentID=StockLocations.ComponentID 
LEFT JOIN Tenants 
ON Packs.TenantID=Tenants.ID AND Packs.ComponentID=Tenants.ComponentID;

---------------------------------------------------

ALTER TABLE [StockOutputOrders] RENAME TO [StockOutputOrders_Old];
ALTER TABLE [StockOutputOrderItems] RENAME TO [StockOutputOrderItems_Old];
ALTER TABLE [StockOutputOrderItemPacks] RENAME TO [StockOutputOrderItemPacks_Old];
ALTER TABLE [StockOutputOrderItemLabels] RENAME TO [StockOutputOrderItemLabels_Old];

DROP INDEX [StockOutputOrders_ID_Index];
DROP INDEX [StockOutputOrders_OrderNumber_Index];
DROP INDEX [StockOutputOrders_BoxNumber_Index];

DROP INDEX [StockOutputOrderItems_ID_Index];
DROP INDEX [StockOutputOrderItems_ArticleCode_Index];
DROP INDEX [StockOutputOrderItems_BatchNumber_Index];
DROP INDEX [StockOutputOrderItems_ExternalID_Index];

DROP INDEX [StockOutputOrderItemPacks_ID_Index];
DROP INDEX [StockOutputOrderItemLabels_ID_Index];

CREATE TABLE [StockOutputOrders](
	[ID] INT NOT NULL,
	[ComponentID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL, 	
	[ParentOrderID] INT NULL,
	[ParentComponentID] INT NULL,
	[ParentTenantID] VARCHAR NULL,
	[SourceID] INT NOT NULL,	
	[OrderNumber] NVARCHAR NOT NULL,
	[BoxNumber] NVARCHAR NOT NULL,
	[ExternalNumber] NVARCHAR NOT NULL,
	[OutputNumber] INT NOT NULL,
	[OutputPoint] INT NOT NULL,
	[Priority] NVARCHAR NOT NULL,
	[State] NVARCHAR NOT NULL,				
	[Created] DATETIME NOT NULL, 	
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	FOREIGN KEY(ParentOrderID, ParentComponentID, ParentTenantID) REFERENCES StockOutputOrders(ID, ComponentID, TenantID),
	PRIMARY KEY(ID, ComponentID, TenantID)
);

CREATE TABLE [StockOutputOrderItems](
	[ID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[PackID] INTEGER NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,
	[BatchNumber] NVARCHAR NOT NULL,
	[ExternalID] NVARCHAR NOT NULL,
	[ExpiryDate] DATETIME NOT NULL, 
	[StockLocationID] VARCHAR NOT NULL, 	
	[MachineLocation] VARCHAR NOT NULL, 
	[RequestedQuantity] INT NOT NULL,	
	[ProcessedQuantity] INT NOT NULL,	
	[RequestedSubItemQuantity] INT NOT NULL,	
	[ProcessedSubItemQuantity] INT NOT NULL,	
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderID, ComponentID, TenantID) REFERENCES StockOutputOrders(ID, ComponentID, TenantID),
	PRIMARY KEY(ID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE TABLE [StockOutputOrderItemPacks] (
	[ID] INTEGER NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[ArticleCode] NVARCHAR NOT NULL,
	[ArticleName] NVARCHAR NOT NULL,	
	[ArticleDosageForm] NVARCHAR NOT NULL, 
	[ArticlePackagingUnit] NVARCHAR NOT NULL, 	
	[ArticleMaxSubItemQuantity] INT NOT NULL,		
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NOT NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[BoxNumber] NVARCHAR NOT NULL,
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL,
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL,  
	[OutputNumber] INT NOT NULL,
	[OutputPoint] INT NOT NULL,
	[LabelState] NVARCHAR NOT NULL,	
	[TenantDescription] NVARCHAR NOT NULL, 	
	[StockLocationID] VARCHAR NOT NULL, 	
	[StockLocationDescription] NVARCHAR NOT NULL, 	
	[MachineLocation] VARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, ComponentID, TenantID),
	PRIMARY KEY(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE TABLE [StockOutputOrderItemLabels](
	[ID] INT NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[TemplateID] NVARCHAR NOT NULL,
	[Content] NVARCHAR NOT NULL,	
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, ComponentID, TenantID),
	PRIMARY KEY(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrders_ID_Index] ON [StockOutputOrders]([ID], [ComponentID], [TenantID]);
CREATE INDEX [StockOutputOrders_OrderNumber_Index] ON [StockOutputOrders]([OrderNumber]);
CREATE INDEX [StockOutputOrders_BoxNumber_Index] ON [StockOutputOrders]([BoxNumber]);

CREATE UNIQUE INDEX [StockOutputOrderItems_ID_Index] ON [StockOutputOrderItems]([ID], [StockOutputOrderID], [ComponentID], [TenantID]);
CREATE INDEX [StockOutputOrderItems_ArticleCode_Index] ON [StockOutputOrderItems]([ArticleCode]);
CREATE INDEX [StockOutputOrderItems_BatchNumber_Index] ON [StockOutputOrderItems]([BatchNumber]);
CREATE INDEX [StockOutputOrderItems_ExternalID_Index] ON [StockOutputOrderItems]([ExternalID]);

CREATE UNIQUE INDEX [StockOutputOrderItemPacks_ID_Index] ON [StockOutputOrderItemPacks]([ID], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);
CREATE UNIQUE INDEX [StockOutputOrderItemLabels_ID_Index] ON [StockOutputOrderItemLabels]([ID], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);

---------------------------------------------------

INSERT INTO [StockOutputOrders]([ID], 
							    [ComponentID], 
							    [TenantID], 
							    [ParentOrderID], 
							    [ParentComponentID], 
							    [SourceID], 
							    [OrderNumber], 
							    [BoxNumber], 
							    [ExternalNumber],
								[OutputNumber],
								[OutputPoint],
								[Priority], 
								[State],
								[Created],
								[LastChange])						 
SELECT  [ID], 
		[ComponentID], 
		'' AS TenantID, 
		[ParentOrderID], 
		[ParentComponentID], 
		[SourceID], 
		[OrderNumber], 
		[BoxNumber], 
		[ExternalNumber],
		[OutputNumber],
		[OutputPoint],
		[Priority], 
		[State],
		[Created],
		[LastChange] 
FROM [StockOutputOrders_Old];

UPDATE [StockOutputOrders] SET [ParentTenantID] = '' WHERE [ParentOrderID] NOT NULL;

INSERT INTO [StockOutputOrderItems]([ID],
									[StockOutputOrderID],
									[ComponentID],	
									[TenantID], 	
									[PackID],		
									[ArticleCode],
									[BatchNumber],
									[ExternalID],
									[ExpiryDate], 
									[StockLocationID], 	
									[MachineLocation], 
									[RequestedQuantity],	
									[ProcessedQuantity],	
									[RequestedSubItemQuantity],	
									[ProcessedSubItemQuantity],
									[LastChange]) 						 
SELECT  [ID],
		[StockOutputOrderID],
		[ComponentID],	
		'' AS TenantID, 	
		[PackID],		
		[ArticleCode],
		[BatchNumber],
		[ExternalID],
		[ExpiryDate], 
		'' AS StockLocationID, 	
		'' AS MachineLocation, 
		[RequestedQuantity],	
		[ProcessedQuantity],	
		[RequestedSubItemQuantity],	
		[ProcessedSubItemQuantity],
		[LastChange] 
FROM [StockOutputOrderItems_Old];

INSERT INTO [StockOutputOrderItemPacks]([ID],
										[StockOutputOrderItemID],
										[StockOutputOrderID],			
										[ComponentID],	
										[TenantID], 	
										[ArticleCode],
										[ArticleName],	
										[ArticleDosageForm], 
										[ArticlePackagingUnit], 	
										[ArticleMaxSubItemQuantity],		
										[BatchNumber], 
										[DeliveryNumber], 
										[ExpiryDate], 
										[ExternalID], 
										[BoxNumber],
										[IsInFridge], 
										[Shape],
										[SubItemQuantity], 
										[ScanCode], 
										[StockInDate], 
										[Depth],
										[Height],
										[Width],  
										[OutputNumber],
										[OutputPoint],
										[LabelState],
										[TenantDescription], 	
										[StockLocationID], 	
										[StockLocationDescription], 	
										[MachineLocation], 
										[LastChange]) 
SELECT  [ID],
		[StockOutputOrderItemID],
		[StockOutputOrderID],			
		[ComponentID],	
		'' AS TenantID, 	
		[ArticleCode],
		[ArticleName],	
		[ArticleDosageForm], 
		[ArticlePackagingUnit], 	
		[ArticleMaxSubItemQuantity],		
		[BatchNumber], 
		[DeliveryNumber], 
		[ExpiryDate], 
		[ExternalID], 
		[BoxNumber],
		[IsInFridge], 
		[Shape],
		[SubItemQuantity], 
		[ScanCode], 
		[StockInDate], 
		[Depth],
		[Height],
		[Width],  
		[OutputNumber],
		[OutputPoint],
		[LabelState],	
		'' AS TenantDescription, 	
		'' AS StockLocationID, 	
		'' AS StockLocationDescription, 	
		'' AS MachineLocation, 
		[LastChange] 
FROM [StockOutputOrderItemPacks_Old];

INSERT INTO [StockOutputOrderItemLabels]([ID],
										 [StockOutputOrderItemID],
										 [StockOutputOrderID],			
										 [ComponentID],	
										 [TenantID], 	
										 [TemplateID],
										 [Content],	
										 [LastChange]) 
SELECT [ID],
	   [StockOutputOrderItemID],
	   [StockOutputOrderID],			
	   [ComponentID],	
	   '' AS TenantID, 	
	   [TemplateID],
	   [Content],	
	   [LastChange] 
FROM [StockOutputOrderItemLabels_Old];

DROP TABLE [StockOutputOrderItemLabels_Old];
DROP TABLE [StockOutputOrderItemPacks_Old];
DROP TABLE [StockOutputOrderItems_Old];
DROP TABLE [StockOutputOrders_Old];

---------------------------------------------------

DROP INDEX [StockDeliveryItemAttributes_ID_Index];
DROP TABLE [StockDeliveryItemAttributes];

---------------------------------------------------

ALTER TABLE [StockDeliverys] RENAME TO [StockDeliverys_Old];
ALTER TABLE [StockDeliveryItems] RENAME TO [StockDeliveryItems_Old];
ALTER TABLE [StockDeliveryItemPacks] RENAME TO [StockDeliveryItemPacks_Old];

DROP INDEX [StockDelivery_ID_Index];
DROP INDEX [StockDelivery_DeliveryNumber_Index];
DROP INDEX [StockDelivery_BoxNumber_Index];

DROP INDEX [StockDeliveryItems_ID_Index];
DROP INDEX [StockDeliveryItems_ArticleCode_Index];
DROP INDEX [StockDeliveryItems_ExternalID_Index];

DROP INDEX [StockDeliveryItemPacks_ID_Index];

---------------------------------------------------

CREATE TABLE [StockDeliverys](
	[ID] INT NOT NULL,		
	[TenantID] VARCHAR NOT NULL, 	
	[SourceID] INT NOT NULL,				
	[DeliveryNumber] NVARCHAR NOT NULL,
	[BoxNumber] NVARCHAR NOT NULL,
	[Priority] NVARCHAR NOT NULL,
	[State] NVARCHAR NOT NULL,				
	[Created] DATETIME NOT NULL,	
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY(ID, TenantID)
);

CREATE TABLE [StockDeliveryItems](
	[ID] INT NOT NULL,	
	[StockDeliveryID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL, 	
	[ArticleCode] NVARCHAR NOT NULL,
	[ExternalID] NVARCHAR NOT NULL,
	[BatchNumber] NVARCHAR NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[DosageForm] NVARCHAR NOT NULL,
	[PackagingUnit] NVARCHAR NOT NULL,
	[RequiresFridge] BOOLEAN NOT NULL,
	[MaxSubItemQuantity] INT NOT NULL,
	[ExpiryDate] DATETIME NOT NULL,
	[StockLocationID] VARCHAR NOT NULL, 	
	[MachineLocation] VARCHAR NOT NULL, 
	[RequestedQuantity] INT NOT NULL,
	[ProcessedQuantity] INT NOT NULL,		
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockDeliveryID, TenantID) REFERENCES StockDeliverys(ID, TenantID),
	PRIMARY KEY(ID, StockDeliveryID, TenantID)
);

CREATE TABLE [StockDeliveryItemPacks] (
	[ID] INTEGER NOT NULL,
	[StockDeliveryItemID] INT NOT NULL,
	[StockDeliveryID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL, 			
	[BatchNumber] NVARCHAR NOT NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL,
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL,  	
	[TenantDescription] NVARCHAR NOT NULL, 	
	[StockLocationID] VARCHAR NOT NULL, 	
	[StockLocationDescription] NVARCHAR NOT NULL, 	
	[MachineLocation] VARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockDeliveryItemID, StockDeliveryID, TenantID) REFERENCES StockDeliveryItems(ID, StockDeliveryID, TenantID),
	PRIMARY KEY(ID, StockDeliveryItemID, StockDeliveryID, TenantID)
);

CREATE UNIQUE INDEX [StockDelivery_ID_Index] ON [StockDeliverys]([ID], [TenantID]);
CREATE INDEX [StockDelivery_DeliveryNumber_Index] ON [StockDeliverys]([DeliveryNumber]);
CREATE INDEX [StockDelivery_BoxNumber_Index] ON [StockDeliverys]([BoxNumber]);

CREATE UNIQUE INDEX [StockDeliveryItems_ID_Index] ON [StockDeliveryItems]([ID], [StockDeliveryID], [TenantID]);
CREATE INDEX [StockDeliveryItems_ArticleCode_Index] ON [StockDeliveryItems]([ArticleCode]);
CREATE INDEX [StockDeliveryItems_ExternalID_Index] ON [StockDeliveryItems]([ExternalID]);

CREATE UNIQUE INDEX [StockDeliveryItemPacks_ID_Index] ON [StockDeliveryItemPacks]([ID], [StockDeliveryItemID], [StockDeliveryID], [TenantID]);

---------------------------------------------------

INSERT INTO [StockDeliverys]([ID],		
							 [TenantID], 	
							 [SourceID],				
							 [DeliveryNumber],
							 [BoxNumber],
							 [Priority],
							 [State],				
							 [Created],	
							 [LastChange]) 
SELECT  [ID],		
		'' AS TenantID, 	
		[SourceID],				
		[DeliveryNumber],
		[BoxNumber],
		[Priority],
		[State],				
		[Created],	
		[LastChange] 
FROM [StockDeliverys_Old];


INSERT INTO [StockDeliveryItems]([ID],	
								 [StockDeliveryID],	
								 [TenantID], 	
								 [ArticleCode],
								 [ExternalID],
								 [BatchNumber],	
								 [Name],
								 [DosageForm],
								 [PackagingUnit],
								 [RequiresFridge],
								 [MaxSubItemQuantity],
								 [ExpiryDate],
								 [StockLocationID], 	
								 [MachineLocation], 
								 [RequestedQuantity],
								 [ProcessedQuantity],		
								 [LastChange]) 
SELECT  [ID],	
		[StockDeliveryID],		
		'' AS TenantID, 	
		[ArticleCode],
		[ExternalID],
		[BatchNumber],	
		[Name],
		[DosageForm],
		[PackagingUnit],
		[RequiresFridge],
		[MaxSubItemQuantity],
		[ExpiryDate],
		'' AS StockLocationID, 	
		'' AS MachineLocation, 
		[RequestedQuantity],
		[ProcessedQuantity],		
		[LastChange] 
FROM [StockDeliveryItems_Old];


INSERT INTO [StockDeliveryItemPacks]([ID],
									 [StockDeliveryItemID],
									 [StockDeliveryID],
									 [TenantID], 			
									 [BatchNumber], 
									 [ExpiryDate], 
									 [ExternalID], 
									 [IsInFridge], 
									 [Shape],
									 [SubItemQuantity], 
									 [ScanCode], 
									 [StockInDate], 
									 [Depth],
									 [Height],
									 [Width],  	
									 [TenantDescription], 	
									 [StockLocationID], 	
									 [StockLocationDescription], 	
									 [MachineLocation], 
									 [LastChange]) 
SELECT  [ID],
		[StockDeliveryItemID],
		[StockDeliveryID],	
		'' AS TenantID, 			
		[BatchNumber], 
		[ExpiryDate], 
		[ExternalID], 
		[IsInFridge], 
		[Shape],
		[SubItemQuantity], 
		[ScanCode], 
		[StockInDate], 
		[Depth],
		[Height],
		[Width],  	
		'' AS TenantDescription, 	
		'' AS StockLocationID, 	
		'' AS StockLocationDescription, 	
		'' AS MachineLocation, 
		[LastChange] 
FROM [StockDeliveryItemPacks_Old];

DROP TABLE [StockDeliveryItemPacks_Old];
DROP TABLE [StockDeliveryItems_Old];
DROP TABLE [StockDeliverys_Old];

---------------------------------------------------

PRAGMA user_version = 14;

---------------------------------------------------

