---- Migration script to update the history database schema from version 2 to 3 ----

---- First create backup tables and backup the existing data ----

CREATE TABLE [STOCKOUTPUTORDERITEMS_BACKUP](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[PackID] INTEGER NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,
	[BatchNumber] NVARCHAR NOT NULL,
	[ExternalID] NVARCHAR NOT NULL,
	[ExpiryDate] DATETIME NOT NULL,
	[RequestedQuantity] INT NOT NULL,	
	[ProcessedQuantity] INT NOT NULL		
);

CREATE TABLE [STOCKOUTPUTORDERITEMPACKS_BACKUP] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[ArticleCode] NVARCHAR NOT NULL,
	[ArticleName] NVARCHAR NOT NULL,	
	[ArticleDosageForm] NVARCHAR NOT NULL, 
	[ArticlePackagingUnit] NVARCHAR NOT NULL, 			
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NOT NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL,
	[OpenedPacksQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL  
);

INSERT INTO STOCKOUTPUTORDERITEMS_BACKUP(ID, HistoryDate, StockOutputOrderID, ComponentID, PackID, 
										 ArticleCode, BatchNumber, ExternalID, ExpiryDate, 
										 RequestedQuantity, ProcessedQuantity) 
SELECT ID, HistoryDate, StockOutputOrderID, ComponentID, PackID, 
	   ArticleCode, BatchNumber, ExternalID, ExpiryDate, 
	   RequestedQuantity, ProcessedQuantity 
FROM StockOutputOrderItems;

INSERT INTO STOCKOUTPUTORDERITEMPACKS_BACKUP(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, 
											 ArticleCode, ArticleName, ArticleDosageForm, ArticlePackagingUnit,
											 BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, IsInFridge, 
											 Shape, OpenedPacksQuantity, ScanCode, StockInDate, Depth, Height, 
											 Width)
SELECT ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, 
	   ArticleCode, ArticleName, ArticleDosageForm, ArticlePackagingUnit,
	   BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, IsInFridge, 
	   Shape, OpenedPacksQuantity, ScanCode, StockInDate, Depth, Height, 
	   Width
FROM StockOutputOrderItemPacks;

---------------------------------------------------------------------

-------------------- Now drop index and tables ----------------------

DROP INDEX StockOutputOrderItems_ID_Index;
DROP TABLE StockOutputOrderItems;

DROP INDEX StockOutputOrderItemPacks_ID_Index;
DROP TABLE StockOutputOrderItemPacks;

---------------------------------------------------------------------

--------------- Create new tables and restore data ------------------

CREATE TABLE [StockOutputOrderItems](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[PackID] INTEGER NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,
	[BatchNumber] NVARCHAR NOT NULL,
	[ExternalID] NVARCHAR NOT NULL,
	[ExpiryDate] DATETIME NOT NULL,
	[RequestedQuantity] INT NOT NULL,	
	[ProcessedQuantity] INT NOT NULL,		
	FOREIGN KEY(HistoryDate, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrders(HistoryDate, ID, ComponentID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItems_ID_Index ON StockOutputOrderItems(ID, HistoryDate, StockOutputOrderID, ComponentID);

---------------------------------------------------	

CREATE TABLE [StockOutputOrderItemPacks] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[ArticleCode] NVARCHAR NOT NULL,
	[ArticleName] NVARCHAR NOT NULL,	
	[ArticleDosageForm] NVARCHAR NOT NULL, 
	[ArticlePackagingUnit] NVARCHAR NOT NULL, 			
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NOT NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[BoxNumber] NVARCHAR NOT NULL,
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL,
	[OpenedPacksQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL,  
	FOREIGN KEY(HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrderItems(HistoryDate, ID, StockOutputOrderID, ComponentID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItemPacks_ID_Index ON StockOutputOrderItemPacks(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID);

---------------------------------------------------------------------

INSERT INTO StockOutputOrderItems(ID, HistoryDate, StockOutputOrderID, ComponentID, PackID, 
								  ArticleCode, BatchNumber, ExternalID, ExpiryDate, 
								  RequestedQuantity, ProcessedQuantity) 
SELECT ID, HistoryDate, StockOutputOrderID, ComponentID, PackID, 
	   ArticleCode, BatchNumber, ExternalID, ExpiryDate, 
	   RequestedQuantity, ProcessedQuantity 
FROM STOCKOUTPUTORDERITEMS_BACKUP;

INSERT INTO StockOutputOrderItemPacks(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, 
									  ArticleCode, ArticleName, ArticleDosageForm, ArticlePackagingUnit,
									  BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, BoxNumber, IsInFridge, 
									  Shape, OpenedPacksQuantity, ScanCode, StockInDate, Depth, Height, 
									  Width)
SELECT ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, 
	   ArticleCode, ArticleName, ArticleDosageForm, ArticlePackagingUnit,
	   BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, '' AS BoxNumber, IsInFridge, 
	   Shape, OpenedPacksQuantity, ScanCode, StockInDate, Depth, Height, 
	   Width
FROM STOCKOUTPUTORDERITEMPACKS_BACKUP;

--------- Finally drop backup tables and update revision ---------------

DROP TABLE STOCKOUTPUTORDERITEMS_BACKUP;
DROP TABLE STOCKOUTPUTORDERITEMPACKS_BACKUP;

PRAGMA user_version = 3;		

------------------------------------------------------------------------