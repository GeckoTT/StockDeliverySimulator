---- Migration script to update the productive database schema from version 12 to 13 ----

---------------------------------------------------

CREATE TABLE [StockDeliveryItemPacks] (
	[ID] INTEGER NOT NULL,
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
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockDeliveryItemID, StockDeliveryID, ComponentID) REFERENCES StockDeliveryItems(ID, StockDeliveryID, ComponentID),
	PRIMARY KEY(ID, StockDeliveryItemID, StockDeliveryID, ComponentID)
);

CREATE UNIQUE INDEX StockDeliveryItemPacks_ID_Index ON StockDeliveryItemPacks(ID, StockDeliveryItemID, StockDeliveryID, ComponentID);

---------------------------------------------------

PRAGMA user_version = 13;

---------------------------------------------------