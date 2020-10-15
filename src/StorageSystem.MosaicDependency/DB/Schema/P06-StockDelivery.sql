---- Mosaic Stock Deliveries, their Items and their Attributes ----

CREATE TABLE [StockDeliverys](
	[ID] INT NOT NULL,			
	[TenantID] VARCHAR NOT NULL, 	
	[SourceID] INT NOT NULL,				-- initiator of the delivery
	[DeliveryNumber] NVARCHAR NOT NULL,
	[BoxNumber] NVARCHAR NOT NULL,
	[Priority] NVARCHAR NOT NULL,
	[State] NVARCHAR NOT NULL,				
	[Created] DATETIME NOT NULL,	
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY(ID, TenantID)
);

CREATE UNIQUE INDEX [StockDelivery_ID_Index] ON [StockDeliverys]([ID], [TenantID]);
CREATE INDEX [StockDelivery_DeliveryNumber_Index] ON [StockDeliverys]([DeliveryNumber]);
CREATE INDEX [StockDelivery_BoxNumber_Index] ON [StockDeliverys]([BoxNumber]);

---------------------------------------------------

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

CREATE UNIQUE INDEX [StockDeliveryItems_ID_Index] ON [StockDeliveryItems]([ID], [StockDeliveryID], [TenantID]);
CREATE INDEX [StockDeliveryItems_ArticleCode_Index] ON [StockDeliveryItems]([ArticleCode]);
CREATE INDEX [StockDeliveryItems_ExternalID_Index] ON [StockDeliveryItems]([ExternalID]);

---------------------------------------------------	
	
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

CREATE UNIQUE INDEX [StockDeliveryItemPacks_ID_Index] ON [StockDeliveryItemPacks]([ID], [StockDeliveryItemID], [StockDeliveryID], [TenantID]);

---------------------------------------------------