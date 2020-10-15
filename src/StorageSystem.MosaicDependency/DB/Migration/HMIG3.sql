---- Migration script to update the history database schema from version 3 to 4 ----

--------------------------------------------------------------------------
--------------- Extend tables with additional columns --------------------

ALTER TABLE StockDeliveryItems ADD COLUMN MaxSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItems ADD COLUMN RequestedSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItems ADD COLUMN ProcessedSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItemPacks ADD COLUMN ArticleMaxSubItemQuantity INT NOT NULL DEFAULT 0;

--------------------------------------------------------------------------
--------------------------- Change column names --------------------------

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
    [ArticleMaxSubItemQuantity]	INT NOT NULL,
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
	[Width] INT NOT NULL  
);

INSERT INTO STOCKOUTPUTORDERITEMPACKS_BACKUP(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
											 ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
											 ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity, ScanCode,
											 StockInDate, Depth, Height, Width) 
SELECT ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
	   ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity, ScanCode,
	   StockInDate, Depth, Height, Width 
FROM StockOutputOrderItemPacks;

DROP INDEX StockOutputOrderItemPacks_ID_Index;
DROP TABLE StockOutputOrderItemPacks;

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
	FOREIGN KEY(HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrderItems(HistoryDate, ID, StockOutputOrderID, ComponentID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItemPacks_ID_Index ON StockOutputOrderItemPacks(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID);

INSERT INTO StockOutputOrderItemPacks(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
									  ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
								 	  ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
									  StockInDate, Depth, Height, Width) 
SELECT ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
	   ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity AS SubItemQuantity, ScanCode,
	   StockInDate, Depth, Height, Width 
FROM STOCKOUTPUTORDERITEMPACKS_BACKUP;

DROP TABLE STOCKOUTPUTORDERITEMPACKS_BACKUP;

-----------------------------------------------------

PRAGMA user_version = 4;

-----------------------------------------------------