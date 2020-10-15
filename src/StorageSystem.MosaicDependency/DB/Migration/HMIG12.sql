---- Migration script to update the history database schema from version 12 to 13 ----

---------------------------------------------------


------------------  update StockOutputOrderItems --------------------
-- rename old table and remove existing index.
ALTER TABLE StockOutputOrderItems RENAME TO StockOutputOrderItems_Old;
DROP INDEX StockOutputOrderItems_ID_Index;

-- create new table and index
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

-- move data to the table
INSERT INTO [StockOutputOrderItems](ID, HistoryDate, StockOutputOrderID, ComponentID, 
       TenantID, PackID, PISArticleCode, RobotArticleCode, RobotArticleName,
	   BatchNumber, SingleBatchNumber, ExternalID, ExpiryDate, 
	   StockLocationID, MachineLocation, RequestedQuantity, 
	   ProcessedQuantity, RequestedSubItemQuantity, ProcessedSubItemQuantity)
SELECT ID, HistoryDate, StockOutputOrderID, ComponentID, 
       TenantID, PackID, '', ArticleCode, ArticleName,
	    BatchNumber, SingleBatchNumber, ExternalID, ExpiryDate, 
		StockLocationID, MachineLocation, RequestedQuantity, 
		ProcessedQuantity, RequestedSubItemQuantity, ProcessedSubItemQuantity
FROM StockOutputOrderItems_Old;

-- remove old table
DROP TABLE StockOutputOrderItems_Old;

---------------------------------------------------------------------


----------------  update StockOutputOrderItemPacks ------------------
-- rename old table and remove existing index.
ALTER TABLE StockOutputOrderItemPacks RENAME TO StockOutputOrderItemPacks_Old;
DROP INDEX StockOutputOrderItemPacks_ID_Index;

-- create new table and index
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


-- move data to the table
INSERT INTO [StockOutputOrderItemPacks] (ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID,
        ComponentID, TenantID, RobotArticleCode, RobotArticleName, RobotArticleDosageForm,
		RobotArticlePackagingUnit, RobotArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
		ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
		StockInDate, Depth, Height, Width, OutputNumber, OutputPoint, LabelState, TenantDescription,
		StockLocationID, StockLocationDescription, MachineLocation)
SELECT ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID,
       ComponentID, TenantID, ArticleCode, ArticleName, ArticleDosageForm,
	   ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
	   StockInDate, Depth, Height, Width, OutputNumber, OutputPoint, LabelState, TenantDescription,
	   StockLocationID, StockLocationDescription, MachineLocation
FROM StockOutputOrderItemPacks_Old;

-- remove old table
DROP TABLE StockOutputOrderItemPacks_Old;
---------------------------------------------------------------------



---------------------------------------------------

PRAGMA user_version = 13;

------------------------------------------------