---- Migration script to update the history database schema from version 7 to 8 ----

---------------------------------------------------

CREATE TABLE [StockDeliveryItemPacks] (
	[ID] INTEGER NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockDeliveryItemID] INT NOT NULL,
	[StockDeliveryID] INT NOT NULL,
	[ComponentID] INT NOT NULL,			
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
	FOREIGN KEY(HistoryDate, StockDeliveryItemID, StockDeliveryID, ComponentID) REFERENCES StockDeliveryItems(HistoryDate, ID, StockDeliveryID, ComponentID),
	PRIMARY KEY(ID, HistoryDate, StockDeliveryItemID, StockDeliveryID, ComponentID)
);

CREATE UNIQUE INDEX StockDeliveryItemPacks_ID_Index ON StockDeliveryItemPacks(ID, HistoryDate, StockDeliveryItemID, StockDeliveryID, ComponentID);

---------------------------------------------------

PRAGMA user_version = 8;

---------------------------------------------------