---- Migration script to update the productive database schema from version 3 to 4 ----

--------------------------------------------------------------------------
--------------- Extend tables with additional columns --------------------

ALTER TABLE Articles ADD COLUMN MaxSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockDeliveryItems ADD COLUMN MaxSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItems ADD COLUMN RequestedSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItems ADD COLUMN ProcessedSubItemQuantity INT NOT NULL DEFAULT 0;
ALTER TABLE StockOutputOrderItemPacks ADD COLUMN ArticleMaxSubItemQuantity INT NOT NULL DEFAULT 0;

--------------------------------------------------------------------------
--------------------------- Change column names --------------------------

CREATE TABLE [PACKS_BACKUP](
	[ID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,	
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL, 
	[OpenedPacksQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL, 
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL,
	[HasChanged] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL
);

CREATE TABLE [PACKATTRIBUTES_BACKUP](
	[PackID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL
);

INSERT INTO PACKS_BACKUP(ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
						 ExpiryDate, ExternalID, IsInFridge, Shape, OpenedPacksQuantity, ScanCode, 
						 StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, 
						 HasChanged, LastChange) 
SELECT ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, IsInFridge, Shape, OpenedPacksQuantity, ScanCode, 
	   StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, 
	   HasChanged, LastChange 
FROM Packs;

INSERT INTO PACKATTRIBUTES_BACKUP(PackID, ArticleID, ComponentID, Name, Value, LastChange) 
SELECT PackID, ArticleID, ComponentID, Name, Value, LastChange 
FROM PackAttributes;

DROP INDEX PackAttributes_ID_Index;
DROP INDEX Packs_ArticleCode_Index;
DROP INDEX Packs_BatchNumber_Index;
DROP INDEX Packs_ExternalID_Index;
DROP INDEX Packs_ID_Index;

DROP TABLE PackAttributes;
DROP TABLE Packs;

CREATE TABLE [Packs] (
	[ID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,	
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NULL, 
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
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL,
	[HasChanged] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ArticleID, ComponentID) REFERENCES Articles(ID, ComponentID),
	PRIMARY KEY(ID, ArticleID, ComponentID)
);

CREATE UNIQUE INDEX Packs_ID_Index ON Packs(ID, ArticleID, ComponentID);
CREATE INDEX Packs_ArticleCode_Index ON Packs(ArticleCode);
CREATE INDEX Packs_BatchNumber_Index ON Packs(BatchNumber);
CREATE INDEX Packs_ExternalID_Index ON Packs(ExternalID);

CREATE TABLE [PackAttributes](
	[PackID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(PackID, ArticleID, ComponentID) REFERENCES Packs(ID, ArticleID, ComponentID),
	PRIMARY KEY(PackID, ArticleID, ComponentID, Name)
);

CREATE UNIQUE INDEX PackAttributes_ID_Index ON PackAttributes(PackID, ArticleID, ComponentID, Name);

INSERT INTO Packs(ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
				  ExpiryDate, ExternalID, IsInFridge, Shape, SubItemQuantity, ScanCode, 
				  StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, 
				  HasChanged, LastChange) 

SELECT ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, IsInFridge, Shape, OpenedPacksQuantity AS SubItemQuantity, ScanCode, 
	   StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, 
	   HasChanged, LastChange 
FROM PACKS_BACKUP;

INSERT INTO PackAttributes(PackID, ArticleID, ComponentID, Name, Value, LastChange) 
SELECT PackID, ArticleID, ComponentID, Name, Value, LastChange 
FROM PACKATTRIBUTES_BACKUP;

DROP TABLE PACKATTRIBUTES_BACKUP;
DROP TABLE PACKS_BACKUP;

-----------------------------------------------------

CREATE TABLE [STOCKOUTPUTORDERITEMPACKS_BACKUP] (
	[ID] INTEGER NOT NULL,
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
	[Width] INT NOT NULL,  
	[LastChange] DATETIME NOT NULL
);

INSERT INTO STOCKOUTPUTORDERITEMPACKS_BACKUP(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
											 ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
											 ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity, ScanCode,
											 StockInDate, Depth, Height, Width, LastChange) 
SELECT ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
	   ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity, ScanCode,
	   StockInDate, Depth, Height, Width, LastChange 
FROM StockOutputOrderItemPacks;

DROP INDEX StockOutputOrderItemPacks_ID_Index;
DROP TABLE StockOutputOrderItemPacks;

CREATE TABLE [StockOutputOrderItemPacks] (
	[ID] INTEGER NOT NULL,
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
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL,  
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, ComponentID),
	PRIMARY KEY(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItemPacks_ID_Index ON StockOutputOrderItemPacks(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID);

INSERT INTO StockOutputOrderItemPacks(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
									  ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
								 	  ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
									  StockInDate, Depth, Height, Width, LastChange) 
SELECT ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, ArticleCode, ArticleName,
	   ArticleDosageForm, ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, OpenedPacksQuantity AS SubItemQuantity, ScanCode,
	   StockInDate, Depth, Height, Width, LastChange 
FROM STOCKOUTPUTORDERITEMPACKS_BACKUP;

DROP TABLE STOCKOUTPUTORDERITEMPACKS_BACKUP;

-----------------------------------------------------

PRAGMA user_version = 4;

-----------------------------------------------------