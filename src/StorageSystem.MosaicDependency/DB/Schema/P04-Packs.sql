---- Mosaic Packs ----
	
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
	[StockLocationID] VARCHAR NOT NULL, 
	[TenantID] VARCHAR NOT NULL,
	[MachineLocation] VARCHAR NOT NULL, 
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL, 
	[IsOnline] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ArticleID, ComponentID) REFERENCES Articles(ID, ComponentID),
	PRIMARY KEY(ID, ArticleID, ComponentID)
);

CREATE UNIQUE INDEX [Packs_ID_Index] ON [Packs]([ID], [ArticleID], [ComponentID]);
CREATE INDEX [Packs_ArticleCode_Index] ON [Packs]([ArticleCode]);
CREATE INDEX [Packs_BatchNumber_Index] ON [Packs]([BatchNumber]);
CREATE INDEX [Packs_ExternalID_Index] ON [Packs]([ExternalID]);
CREATE INDEX [Packs_StockLocationID_Index] ON [Packs]([StockLocationID]);
CREATE INDEX [Packs_TenantID_Index] ON [Packs]([TenantID]);
CREATE INDEX [Packs_MachineLocation_Index] ON [Packs]([MachineLocation]);

-----------------------------------------------------


