
---- Migration script to update the productive database schema from version 15 to 16 ----

---------------------------------------------------

-- extend packs table
ALTER TABLE [Packs] ADD COLUMN [IsOnline] BOOLEAN NOT NULL DEFAULT 0;

-- extend view
DROP VIEW [PackAndArticles];

CREATE VIEW [PackAndArticles] AS 
SELECT 	Packs.ID, 
		Packs.ArticleID, 
		Packs.ArticleCode,
		Packs.ComponentID,  
		Packs.BatchNumber,
		Packs.DeliveryNumber,
		Packs.ExpiryDate,
		Packs.ExternalID,
		Packs.IsInFridge,
		Packs.Shape,
		Packs.SubItemQuantity,
		Packs.ScanCode,
		Packs.StockInDate,
		Packs.Depth,
		Packs.Height,
		Packs.Width,
		Packs.StockLocationID, 
	    Packs.TenantID,
	    Packs.MachineLocation, 
		Packs.IsAvailable,
		Packs.IsBlocked,
		Packs.IsOnline,
		Packs.LastChange,
		Articles.Name,
		Articles.Code,
		Articles.DosageForm,
		Articles.PackagingUnit,
		Articles.RequiresFridge,
		Articles.MaxSubItemQuantity,
		StockLocations.Description AS StockLocationDescription,
		Tenants.Description AS TenantDescription

FROM Packs 
LEFT JOIN Articles 
ON Packs.ArticleID=Articles.ID AND Packs.ComponentID=Articles.ComponentID
LEFT JOIN StockLocations 
ON Packs.StockLocationID=StockLocations.ID AND Packs.ComponentID=StockLocations.ComponentID
LEFT JOIN Tenants 
ON Packs.TenantID=Tenants.ID AND Packs.ComponentID=Tenants.ComponentID;


-- change priority type in stock output orders
CREATE TABLE [STOCKOUTPUTORDERS_BACKUP](
	[ID] INT NOT NULL,
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
	[LastChange] DATETIME NOT NULL
);

INSERT INTO STOCKOUTPUTORDERS_BACKUP(ID, ComponentID, TenantID, ParentOrderID, ParentComponentID,
									 ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
									 OutputNumber, OutputPoint, Priority, State, Created, LastChange)
SELECT ID, ComponentID, TenantID, ParentOrderID, ParentComponentID,
	   ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
	   OutputNumber, OutputPoint, 3 AS Priority, State, Created, LastChange 
FROM StockOutputOrders;

DROP INDEX [StockOutputOrders_BoxNumber_Index];
DROP INDEX [StockOutputOrders_OrderNumber_Index];
DROP INDEX [StockOutputOrders_ID_Index];
DROP TABLE [StockOutputOrders];

CREATE TABLE [StockOutputOrders](
	[ID] INT NOT NULL,
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
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	FOREIGN KEY(ParentOrderID, ParentComponentID, ParentTenantID) REFERENCES StockOutputOrders(ID, ComponentID, TenantID),
	PRIMARY KEY(ID, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrders_ID_Index] ON [StockOutputOrders]([ID], [ComponentID], [TenantID]);
CREATE INDEX [StockOutputOrders_OrderNumber_Index] ON [StockOutputOrders]([OrderNumber]);
CREATE INDEX [StockOutputOrders_BoxNumber_Index] ON [StockOutputOrders]([BoxNumber]);

INSERT INTO StockOutputOrders(ID, ComponentID, TenantID, ParentOrderID, ParentComponentID,
							  ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
							  OutputNumber, OutputPoint, Priority, State, Created, LastChange)
SELECT ID, ComponentID, TenantID, ParentOrderID, ParentComponentID,
	   ParentTenantID, SourceID, OrderNumber, BoxNumber, ExternalNumber,
	   OutputNumber, OutputPoint, Priority, State, Created, LastChange 
FROM STOCKOUTPUTORDERS_BACKUP;

DROP TABLE STOCKOUTPUTORDERS_BACKUP;

---------------------------------------------------

PRAGMA user_version = 16;

---------------------------------------------------