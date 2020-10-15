
---- Migration script to update the history database schema from version 7 to 8 ----

---------------------------------------------------

ALTER TABLE [StockOutputOrders] RENAME TO [StockOutputOrders_Old];
ALTER TABLE [StockOutputOrderItems] RENAME TO [StockOutputOrderItems_Old];
ALTER TABLE [StockOutputOrderItemPacks] RENAME TO [StockOutputOrderItemPacks_Old];
ALTER TABLE [StockOutputOrderItemLabels] RENAME TO [StockOutputOrderItemLabels_Old];

DROP INDEX [StockOutputOrders_ID_Index];
DROP INDEX [StockOutputOrderItems_ID_Index];
DROP INDEX [StockOutputOrderItemPacks_ID_Index];
DROP INDEX [StockOutputOrderItemLabels_ID_Index];


CREATE TABLE [StockOutputOrders](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
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
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	FOREIGN KEY(ParentOrderID, HistoryDate, ParentComponentID, ParentTenantID) REFERENCES StockOutputOrders(ID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, ComponentID, TenantID)
);


CREATE TABLE [StockOutputOrderItems](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
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
	FOREIGN KEY(StockOutputOrderID, HistoryDate, ComponentID, TenantID) REFERENCES StockOutputOrders(ID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderID, ComponentID, TenantID)
);

	
CREATE TABLE [StockOutputOrderItemPacks] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
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
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, HistoryDate, ComponentID, TenantID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID)
);


CREATE TABLE [StockOutputOrderItemLabels](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[TemplateID] NVARCHAR NOT NULL,
	[Content] NVARCHAR NOT NULL,	
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, HistoryDate, ComponentID, TenantID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrders_ID_Index] ON [StockOutputOrders]([ID], [HistoryDate], [ComponentID], [TenantID]);
CREATE UNIQUE INDEX [StockOutputOrderItems_ID_Index] ON [StockOutputOrderItems]([ID], [HistoryDate], [StockOutputOrderID], [ComponentID], [TenantID]);
CREATE UNIQUE INDEX [StockOutputOrderItemPacks_ID_Index] ON [StockOutputOrderItemPacks]([ID], [HistoryDate], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);
CREATE UNIQUE INDEX [StockOutputOrderItemLabels_ID_Index] ON [StockOutputOrderItemLabels]([ID], [HistoryDate], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);

---------------------------------------------------

INSERT INTO [StockOutputOrders]([ID], 
								[HistoryDate],
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
								[Created])						 
SELECT  [ID], 
		[HistoryDate],
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
		[Created]  
FROM [StockOutputOrders_Old];

UPDATE [StockOutputOrders] SET [ParentTenantID] = '' WHERE [ParentOrderID] NOT NULL;

INSERT INTO [StockOutputOrderItems]([ID],
									[HistoryDate],
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
									[ProcessedSubItemQuantity]) 						 
SELECT  [ID],
		[HistoryDate],
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
		[ProcessedSubItemQuantity] 
FROM [StockOutputOrderItems_Old];

INSERT INTO [StockOutputOrderItemPacks]([ID],
										[HistoryDate],
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
										[MachineLocation]) 
SELECT  [ID],
		[HistoryDate],
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
		'' AS MachineLocation 
FROM [StockOutputOrderItemPacks_Old];

INSERT INTO [StockOutputOrderItemLabels]([ID],
										 [HistoryDate],
										 [StockOutputOrderItemID],
										 [StockOutputOrderID],			
										 [ComponentID],	
										 [TenantID], 	
										 [TemplateID],
										 [Content]) 
SELECT [ID],
	   [HistoryDate],
	   [StockOutputOrderItemID],
	   [StockOutputOrderID],			
	   [ComponentID],	
	   '' AS TenantID, 	
	   [TemplateID],
	   [Content] 
FROM [StockOutputOrderItemLabels_Old];

DROP TABLE [StockOutputOrderItemLabels_Old];
DROP TABLE [StockOutputOrderItemPacks_Old];
DROP TABLE [StockOutputOrderItems_Old];
DROP TABLE [StockOutputOrders_Old];

---------------------------------------------------

ALTER TABLE [StockDeliverys] RENAME TO [StockDeliverys_Old];
ALTER TABLE [StockDeliveryItems] RENAME TO [StockDeliveryItems_Old];
ALTER TABLE [StockDeliveryItemPacks] RENAME TO [StockDeliveryItemPacks_Old];

DROP INDEX [StockDelivery_ID_Index];
DROP INDEX [StockDeliveryItems_ID_Index];
DROP INDEX [StockDeliveryItemPacks_ID_Index];

---------------------------------------------------

CREATE TABLE [StockDeliverys](
	[ID] INT NOT NULL,	
	[HistoryDate] DATETIME NOT NULL,
	[TenantID] VARCHAR NOT NULL, 	
	[SourceID] INT NOT NULL,				-- initiator of the delivery
	[DeliveryNumber] NVARCHAR NOT NULL,
	[BoxNumber] NVARCHAR NOT NULL,
	[Priority] NVARCHAR NOT NULL,
	[State] NVARCHAR NOT NULL,				
	[Created] DATETIME NOT NULL,	
	PRIMARY KEY(ID, HistoryDate, TenantID)
);


CREATE TABLE [StockDeliveryItems](
	[ID] INT NOT NULL,	
	[HistoryDate] DATETIME NOT NULL,
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
	FOREIGN KEY(StockDeliveryID, HistoryDate, TenantID) REFERENCES StockDeliverys(ID, HistoryDate, TenantID),
	PRIMARY KEY(ID, HistoryDate, StockDeliveryID, TenantID)
);

	
CREATE TABLE [StockDeliveryItemPacks] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
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
	FOREIGN KEY(StockDeliveryItemID, StockDeliveryID, HistoryDate, TenantID) REFERENCES StockDeliveryItems(ID, StockDeliveryID, HistoryDate, TenantID),
	PRIMARY KEY(ID, HistoryDate, StockDeliveryItemID, StockDeliveryID, TenantID)
);

CREATE UNIQUE INDEX [StockDelivery_ID_Index] ON [StockDeliverys]([ID], [HistoryDate], [TenantID]);
CREATE UNIQUE INDEX [StockDeliveryItems_ID_Index] ON [StockDeliveryItems]([ID], [HistoryDate], [StockDeliveryID], [TenantID]);
CREATE UNIQUE INDEX [StockDeliveryItemPacks_ID_Index] ON [StockDeliveryItemPacks]([ID], [HistoryDate], [StockDeliveryItemID], [StockDeliveryID], [TenantID]);

---------------------------------------------------

INSERT INTO [StockDeliverys]([ID],	
							 [HistoryDate],
							 [TenantID], 	
							 [SourceID],				
							 [DeliveryNumber],
							 [BoxNumber],
							 [Priority],
							 [State],				
							 [Created]) 
SELECT  [ID],	
		[HistoryDate],	
		'' AS TenantID, 	
		[SourceID],				
		[DeliveryNumber],
		[BoxNumber],
		[Priority],
		[State],				
		[Created]  
FROM [StockDeliverys_Old];


INSERT INTO [StockDeliveryItems]([ID],	
								 [HistoryDate],
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
								 [ProcessedQuantity]) 
SELECT  [ID],
		[HistoryDate],	
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
		[ProcessedQuantity] 
FROM [StockDeliveryItems_Old];


INSERT INTO [StockDeliveryItemPacks]([ID],
									 [HistoryDate],
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
									 [MachineLocation]) 
SELECT  [ID],
		[HistoryDate],
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
		'' AS MachineLocation 
FROM [StockDeliveryItemPacks_Old];

DROP TABLE [StockDeliveryItemPacks_Old];
DROP TABLE [StockDeliveryItems_Old];
DROP TABLE [StockDeliverys_Old];

---------------------------------------------------

PRAGMA user_version = 9;

---------------------------------------------------