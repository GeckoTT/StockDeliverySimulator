---- Migration script to update the productive database schema from version 18 to 19 ----

------------ rename Articles to RobotArticles + update --------------
-- create new table and index
CREATE TABLE [RobotArticles](
	[ID] INT NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Code] NVARCHAR NOT NULL, 	
	[Name] NVARCHAR NOT NULL,	
	[DosageForm] NVARCHAR NOT NULL, 
	[PackagingUnit] NVARCHAR NOT NULL, 
	[RequiresFridge] BOOLEAN NOT NULL, 
	[MaxSubItemQuantity] INT NOT NULL,
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	PRIMARY KEY(ID, ComponentID)
);

CREATE UNIQUE INDEX [RobotArticles_ID_Index] ON [RobotArticles]([ID], [ComponentID]);
CREATE INDEX [RobotArticles_Code_Index] ON [RobotArticles]([Code]);
CREATE INDEX [RobotArticles_Name_Index] ON [RobotArticles]([Name]);


-- move data to the table
INSERT INTO [RobotArticles](ID, ComponentID, Code, Name, DosageForm,
       PackagingUnit, RequiresFridge, MaxSubItemQuantity, IsAvailable,
	   IsBlocked, LastChange) 
SELECT ID, ComponentID, Code, Name, DosageForm,
       PackagingUnit, RequiresFridge, MaxSubItemQuantity, IsAvailable,
	   IsBlocked, LastChange
FROM Articles;

-- remove old table
DROP INDEX Articles_Name_Index;
DROP INDEX Articles_Code_Index;
DROP INDEX Articles_ID_Index;
DROP TABLE Articles;
---------------------------------------------------------------------


------------ rename Packs to RobotPacks + update --------------
-- create new table and index	
CREATE TABLE [RobotPacks] (
	[ID] INT NOT NULL,
	[RobotArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,		
	[RobotArticleCode] NVARCHAR NOT NULL,	
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
	[StockLocationID] VARCHAR NOT NULL, 
	[TenantID] VARCHAR NOT NULL,
	[MachineLocation] VARCHAR NOT NULL, 
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL, 
	[IsOnline] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(RobotArticleID, ComponentID) REFERENCES RobotArticles(ID, ComponentID),
	PRIMARY KEY(ID, RobotArticleID, ComponentID)
);

CREATE UNIQUE INDEX [RobotPacks_ID_Index] ON [RobotPacks]([ID], [RobotArticleID], [ComponentID]);
CREATE INDEX [RobotPacks_ArticleCode_Index] ON [RobotPacks]([RobotArticleCode]);
CREATE INDEX [RobotPacks_BatchNumber_Index] ON [RobotPacks]([BatchNumber]);
CREATE INDEX [RobotPacks_ExternalID_Index] ON [RobotPacks]([ExternalID]);
CREATE INDEX [RobotPacks_StockLocationID_Index] ON [RobotPacks]([StockLocationID]);
CREATE INDEX [RobotPacks_TenantID_Index] ON [RobotPacks]([TenantID]);
CREATE INDEX [RobotPacks_MachineLocation_Index] ON [RobotPacks]([MachineLocation]);

-- move data to the table
INSERT INTO [RobotPacks](ID, RobotArticleID, ComponentID, RobotArticleCode,
       BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, IsInFridge, Shape,
	   SubItemQuantity, ScanCode, StockInDate, Depth, Height, Width, 
	   StockLocationID, TenantID, MachineLocation, IsAvailable, IsBlocked,
	   IsOnline, LastChange) 
SELECT ID, ArticleID, ComponentID, ArticleCode,
       BatchNumber, DeliveryNumber, ExpiryDate, ExternalID, IsInFridge, Shape,
	   SubItemQuantity, ScanCode, StockInDate, Depth, Height, Width, 
	   StockLocationID, TenantID, MachineLocation, IsAvailable, IsBlocked,
	   IsOnline, LastChange
FROM Packs;

-- remove old table
DROP INDEX Packs_MachineLocation_Index;
DROP INDEX Packs_TenantID_Index;
DROP INDEX Packs_StockLocationID_Index;
DROP INDEX Packs_ExternalID_Index;
DROP INDEX Packs_BatchNumber_Index;
DROP INDEX Packs_ArticleCode_Index;
DROP INDEX Packs_ID_Index;
DROP TABLE Packs;
---------------------------------------------------------------------


------------------  update StockOutputOrderItems --------------------
-- rename old table and remove existing index.
ALTER TABLE StockOutputOrderItems RENAME TO StockOutputOrderItems_Old;
DROP INDEX StockOutputOrderItems_ExternalID_Index;
DROP INDEX StockOutputOrderItems_BatchNumber_Index;
DROP INDEX StockOutputOrderItems_ArticleCode_Index;
DROP INDEX StockOutputOrderItems_ID_Index;

-- create new table and index
CREATE TABLE [StockOutputOrderItems](
	[ID] INT NOT NULL,
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
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderID, ComponentID, TenantID) REFERENCES StockOutputOrders(ID, ComponentID, TenantID),
	PRIMARY KEY(ID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrderItems_ID_Index] ON [StockOutputOrderItems]([ID], [StockOutputOrderID], [ComponentID], [TenantID]);
CREATE INDEX [StockOutputOrderItems_ArticleCode_Index] ON [StockOutputOrderItems]([RobotArticleCode]);
CREATE INDEX [StockOutputOrderItems_BatchNumber_Index] ON [StockOutputOrderItems]([BatchNumber]);
CREATE INDEX [StockOutputOrderItems_ExternalID_Index] ON [StockOutputOrderItems]([ExternalID]);

-- move data to the table
INSERT INTO [StockOutputOrderItems](ID, StockOutputOrderID, ComponentID, 
       TenantID, PackID, PISArticleCode, RobotArticleCode, RobotArticleName,
	    BatchNumber, SingleBatchNumber, ExternalID, ExpiryDate, 
		StockLocationID, MachineLocation, RequestedQuantity, 
		ProcessedQuantity, RequestedSubItemQuantity, ProcessedSubItemQuantity, LastChange)
SELECT ID, StockOutputOrderID, ComponentID, 
       TenantID, PackID, '', ArticleCode, ArticleName,
	    BatchNumber, SingleBatchNumber, ExternalID, ExpiryDate, 
		StockLocationID, MachineLocation, RequestedQuantity, 
		ProcessedQuantity, RequestedSubItemQuantity, ProcessedSubItemQuantity, LastChange
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
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID) REFERENCES StockOutputOrderItems(ID, StockOutputOrderID, ComponentID, TenantID),
	PRIMARY KEY(ID, StockOutputOrderItemID, StockOutputOrderID, ComponentID, TenantID)
);

CREATE UNIQUE INDEX [StockOutputOrderItemPacks_ID_Index] ON [StockOutputOrderItemPacks]([ID], [StockOutputOrderItemID], [StockOutputOrderID], [ComponentID], [TenantID]);


-- move data to the table
INSERT INTO [StockOutputOrderItemPacks] (ID, StockOutputOrderItemID, StockOutputOrderID,
        ComponentID, TenantID, RobotArticleCode, RobotArticleName, RobotArticleDosageForm,
		RobotArticlePackagingUnit, RobotArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
		ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
		StockInDate, Depth, Height, Width, OutputNumber, OutputPoint, LabelState, TenantDescription,
		StockLocationID, StockLocationDescription, MachineLocation, LastChange)
SELECT ID, StockOutputOrderItemID, StockOutputOrderID,
        ComponentID, TenantID, ArticleCode, ArticleName, ArticleDosageForm,
		ArticlePackagingUnit, ArticleMaxSubItemQuantity, BatchNumber, DeliveryNumber,
		ExpiryDate, ExternalID, BoxNumber, IsInFridge, Shape, SubItemQuantity, ScanCode,
		StockInDate, Depth, Height, Width, OutputNumber, OutputPoint, LabelState, TenantDescription,
		StockLocationID, StockLocationDescription, MachineLocation, LastChange
FROM StockOutputOrderItemPacks_Old;

-- remove old table
DROP TABLE StockOutputOrderItemPacks_Old;
---------------------------------------------------------------------

------------------- update PackAndArticles view ---------------------
DROP VIEW PackAndArticles;

CREATE VIEW [PackAndArticles] AS 
SELECT 	RobotPacks.ID, 
		RobotPacks.RobotArticleID, 
		RobotPacks.RobotArticleCode,
		RobotPacks.ComponentID,  
		RobotPacks.BatchNumber,
		RobotPacks.DeliveryNumber,
		RobotPacks.ExpiryDate,
		RobotPacks.ExternalID,
		RobotPacks.IsInFridge,
		RobotPacks.Shape,
		RobotPacks.SubItemQuantity,
		RobotPacks.ScanCode,
		RobotPacks.StockInDate,
		RobotPacks.Depth,
		RobotPacks.Height,
		RobotPacks.Width,
		RobotPacks.StockLocationID, 
	    RobotPacks.TenantID,
	    RobotPacks.MachineLocation, 
		RobotPacks.IsAvailable,
		RobotPacks.IsBlocked,
		RobotPacks.IsOnline,
		RobotPacks.LastChange,
		RobotArticles.Name,
		RobotArticles.Code,
		RobotArticles.DosageForm,
		RobotArticles.PackagingUnit,
		RobotArticles.RequiresFridge,
		RobotArticles.MaxSubItemQuantity,
		StockLocations.Description AS StockLocationDescription,
		Tenants.Description AS TenantDescription

FROM RobotPacks 
LEFT JOIN RobotArticles 
ON RobotPacks.RobotArticleID=RobotArticles.ID AND RobotPacks.ComponentID=RobotArticles.ComponentID
LEFT JOIN StockLocations 
ON RobotPacks.StockLocationID=StockLocations.ID AND RobotPacks.ComponentID=StockLocations.ComponentID
LEFT JOIN Tenants 
ON RobotPacks.TenantID=Tenants.ID AND RobotPacks.ComponentID=Tenants.ComponentID;
---------------------------------------------------------------------


---------- rename MasterArticles to PISArticles + update ------------

-- create new table and index
CREATE TABLE [PisArticles](
	[ID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL,
	[ParentPisArticleID] INT NULL,
	[Code] NVARCHAR NOT NULL, 	
	[Name] NVARCHAR NOT NULL,	
	[DosageForm] NVARCHAR NOT NULL, 
	[PackagingUnit] NVARCHAR NOT NULL, 	
	[MaxSubItemQuantity] INT NOT NULL,	
	[RobotArticleCode] NVARCHAR NULL,
	[StockLocationID] VARCHAR NOT NULL,
	[MachineLocation] VARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [TenantID]),
	FOREIGN KEY(ParentPisArticleID) REFERENCES PisArticles(ID)
);

CREATE UNIQUE INDEX [PisArticles_ID_Index] ON [PisArticles]([ID], [TenantID]);
CREATE INDEX [PisArticles_Code_Index] ON [PisArticles]([Code]);
CREATE INDEX [PisArticles_Name_Index] ON [PisArticles]([Name]);
CREATE INDEX [PisArticles_StockLocationID_Index] ON [PisArticles]([StockLocationID]);

-- move data to the table
INSERT INTO [PisArticles](ID, TenantID, ParentPisArticleID, Code, Name,
       DosageForm, PackagingUnit, MaxSubItemQuantity, RobotArticleCode,
	   StockLocationID, MachineLocation, LastChange) 
SELECT ID, TenantID, null, Code, Name,
       DosageForm, PackagingUnit, MaxSubItemQuantity, Code,
	   StockLocationID, MachineLocation, LastChange
FROM MasterArticles;

-- remove old table
DROP INDEX MasterArticles_StockLocationID_Index;
DROP INDEX MasterArticles_Name_Index;
DROP INDEX MasterArticles_Code_Index;
DROP INDEX MasterArticles_ID_Index;
DROP TABLE MasterArticles;

---------------------------------------------------------------------


------------- Create PIS article related new tables -----------------

CREATE TABLE [PisArticleScanCodes] (
	[PisArticleID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL,
	[ScanCode] NVARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(PisArticleID) REFERENCES PisArticles(ID),
	PRIMARY KEY(TenantID, ScanCode)
);

CREATE TABLE [PisArticleAttributes](
	[PisArticleID] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL,
	[Name] VARCHAR NOT NULL,
	[Value] NVARCHAR NOT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(PisArticleID) REFERENCES PisArticles(ID),
	PRIMARY KEY(PisArticleID, Name)
);
---------------------------------------------------------------------


---------------------------------------------------

PRAGMA user_version = 19;

---------------------------------------------------