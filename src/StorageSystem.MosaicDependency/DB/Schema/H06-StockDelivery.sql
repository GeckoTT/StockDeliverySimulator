---- Mosaic Stock Stock Deliveries and their Items ----

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

CREATE UNIQUE INDEX [StockDelivery_ID_Index] ON [StockDeliverys]([ID], [HistoryDate], [TenantID]);

---------------------------------------------------

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

CREATE UNIQUE INDEX [StockDeliveryItems_ID_Index] ON [StockDeliveryItems]([ID], [HistoryDate], [StockDeliveryID], [TenantID]);

---------------------------------------------------	
	
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

CREATE UNIQUE INDEX [StockDeliveryItemPacks_ID_Index] ON [StockDeliveryItemPacks]([ID], [HistoryDate], [StockDeliveryItemID], [StockDeliveryID], [TenantID]);

---------------------------------------------------
