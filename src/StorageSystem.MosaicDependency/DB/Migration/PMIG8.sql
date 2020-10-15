---- Migration script to update the productive database schema from version 8 to 9 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [LabelState] NVARCHAR NOT NULL DEFAULT 'NotLabelled';

---------------------------------------------------

CREATE TABLE [StockOutputOrderItemLabels](
	[ID] INT NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TemplateID] NVARCHAR NOT NULL,
	[Content] NVARCHAR NOT NULL,	
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, ComponentID),
	PRIMARY KEY(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItemLabels_ID_Index ON StockOutputOrderItemLabels(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID);

---------------------------------------------------

PRAGMA user_version = 9;

---------------------------------------------------