
---- Migration script to update the history database schema from version 10 to 11 ----

---------------------------------------------------

-- change priority type in stock output orders
CREATE TABLE [STOCKOUTPUTORDERS_BACKUP](
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
	[Created] DATETIME NOT NULL 	
);

INSERT INTO STOCKOUTPUTORDERS_BACKUP(ID, HistoryDate, ComponentID, TenantID, ParentOrderID, ParentComponentID,
									 ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
									 OutputNumber, OutputPoint, Priority, State, Created)
SELECT ID, HistoryDate, ComponentID, TenantID, ParentOrderID, ParentComponentID,
	   ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
	   OutputNumber, OutputPoint, 3 AS Priority, State, Created  
FROM StockOutputOrders;

DROP INDEX [StockOutputOrders_ID_Index];
DROP TABLE [StockOutputOrders];

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
	FOREIGN KEY(ParentOrderID, HistoryDate, ParentComponentID, ParentTenantID) REFERENCES StockOutputOrders(ID, HistoryDate, ComponentID, TenantID),
	PRIMARY KEY(ID, HistoryDate, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrders_ID_Index] ON [StockOutputOrders]([ID], [HistoryDate], [ComponentID], [TenantID]);

INSERT INTO StockOutputOrders(ID, HistoryDate, ComponentID, TenantID, ParentOrderID, ParentComponentID,
							  ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
							  OutputNumber, OutputPoint, Priority, State, Created)
SELECT ID, HistoryDate, ComponentID, TenantID, ParentOrderID, ParentComponentID,
	   ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
	   OutputNumber, OutputPoint, Priority, State, Created  
FROM STOCKOUTPUTORDERS_BACKUP;

DROP TABLE STOCKOUTPUTORDERS_BACKUP;

---------------------------------------------------

PRAGMA user_version = 11;

---------------------------------------------------