---- Migration script to update the history database schema from version 5 to 6 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [LabelState] NVARCHAR NOT NULL DEFAULT 'NotLabelled';

---------------------------------------------------

CREATE TABLE [StockOutputOrderItemLabels](
	[ID] INT NOT NULL,
	[HistoryDate] DATETIME NOT NULL,
	[StockOutputOrderItemID] INT NOT NULL,
	[StockOutputOrderID] INT NOT NULL,			
	[ComponentID] INT NOT NULL,	
	[TemplateID] NVARCHAR NOT NULL,
	[Content] NVARCHAR NOT NULL,	
	FOREIGN KEY(HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID) REFERENCES StockOutputOrderItems(HistoryDate, ID, StockOutputOrderID, ComponentID),
	PRIMARY KEY(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID)
);

CREATE UNIQUE INDEX StockOutputOrderItemLabels_ID_Index ON StockOutputOrderItemLabels(ID, HistoryDate, StockOutputOrderItemID, StockOutputOrderID, ComponentID);

---------------------------------------------------

PRAGMA user_version = 6;

---------------------------------------------------