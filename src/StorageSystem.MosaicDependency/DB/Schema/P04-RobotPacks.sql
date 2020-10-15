---- Mosaic Packs ----
	
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

-----------------------------------------------------


