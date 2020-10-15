---- Mosaic Stock Output Orders and their Items ----

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
	[Priority] INT NOT NULL,
	[State] NVARCHAR NOT NULL,				
	[Created] DATETIME NOT NULL, 	
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	FOREIGN KEY(ParentOrderID, HistoryDate, ParentComponentID, ParentTenantID) REFERENCES StockOutputOrders(ID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrders_ID_Index] ON [StockOutputOrders]([ID], [HistoryDate], [ComponentID], [TenantID]);

---------------------------------------------------

CREATE TABLE [StockOutputOrderItems](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[PackID] INTEGER NOT NULL,
	[PISArticleCode] NVARCHAR NOT NULL,
	[RobotArticleCode] NVARCHAR NOT NULL,
	[RobotArticleName] NVARCHAR NOT NULL,
	[BatchNumber] NVARCHAR NOT NULL,
	[SingleBatchNumber] BOOLEAN NOT NULL,
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

CREATE UNIQUE INDEX [StockOutputOrderItems_ID_Index] ON [StockOutputOrderItems]([ID], [HistoryDate], [StockOutputOrderID], [ComponentID], [TenantID]);

---------------------------------------------------	
	
CREATE TABLE [StockOutputOrderItemPacks] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TenantID] VARCHAR NOT NULL, 	
	[RobotArticleCode] NVARCHAR NOT NULL,
	[RobotArticleName] NVARCHAR NOT NULL,	
	[RobotArticleDosageForm] NVARCHAR NOT NULL, 
	[RobotArticlePackagingUnit] NVARCHAR NOT NULL, 	
	[RobotArticleMaxSubItemQuantity] INT NOT NULL,		
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

CREATE UNIQUE INDEX [StockOutputOrderItemPacks_ID_Index] ON [StockOutputOrderItemPacks]([ID], [HistoryDate], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);

---------------------------------------------------

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

CREATE UNIQUE INDEX [StockOutputOrderItemLabels_ID_Index] ON [StockOutputOrderItemLabels]([ID], [HistoryDate], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);

---------------------------------------------------
