---- GUI related data model to allow fast article and pack based queries ----

CREATE TABLE [GuiArticles](
	[ID] VARCHAR PRIMARY KEY NOT NULL,
	[Name] NVARCHAR NOT NULL,	
	[Code] NVARCHAR NOT NULL, 
	[Type] NVARCHAR NOT NULL, 	
	[Unit] NVARCHAR NOT NULL,
	[IsFridge] BOOLEAN NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL, 
	[PackCount] INT NOT NULL,
	[TenantID] VARCHAR NOT NULL, 	
	[TenantDescription] NVARCHAR NOT NULL, 	
	[StockLocationID] VARCHAR NOT NULL, 	
	[StockLocationDescription] NVARCHAR NOT NULL, 	
	[LastChange] DATETIME NOT NULL
);

CREATE INDEX GuiArticles_Code_Index ON GuiArticles(Code);
CREATE INDEX GuiArticles_Name_Index ON GuiArticles(Name);
CREATE INDEX GuiArticles_TenantID_Index ON GuiArticles(TenantID);
CREATE INDEX GuiArticles_StockLocationID_Index ON GuiArticles(StockLocationID);

---------------------------------------------------

CREATE TABLE [GuiPacks] (
	[ID] INT NOT NULL,
	[ComponentID] INT NOT NULL,
	[ArticleName] NVARCHAR NOT NULL,
	[ArticleCode] NVARCHAR NOT NULL,
	[Batch] NVARCHAR NOT NULL, 
	[IsSpecial] BOOLEAN NOT NULL, 
	[IsFridge] BOOLEAN NOT NULL, 
	[EntryDate] DATETIME NOT NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL,
	[ExternalIdCode] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NOT NULL,
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL, 
	[StorageSystemName] NVARCHAR NOT NULL,
	[TenantID] VARCHAR NOT NULL, 	
	[TenantDescription] NVARCHAR NOT NULL, 	
	[StockLocationID] VARCHAR NOT NULL, 	
	[StockLocationDescription] NVARCHAR NOT NULL, 	
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY(ID, ComponentID)
);

CREATE UNIQUE INDEX GuiPacks_ID_Index ON GuiPacks(ID, ComponentID);
CREATE INDEX GuiPacks_Code_Index ON GuiPacks(ArticleCode);
CREATE INDEX GuiPacks_Name_Index ON GuiPacks(ArticleName);
CREATE INDEX GuiPacks_TenantID_Index ON GuiPacks(TenantID);
CREATE INDEX GuiPacks_StockLocationID_Index ON GuiPacks(StockLocationID);

---------------------------------------------------
