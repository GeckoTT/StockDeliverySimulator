---- Migration script to update the stock cache database schema from version 1 to 2 ----

---------------------------------------------------

DROP INDEX [GuiArticles_Code_Index];
DROP INDEX [GuiArticles_Name_Index];
DROP TABLE [GuiArticles];

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

CREATE INDEX [GuiArticles_Code_Index] ON [GuiArticles]([Code]);
CREATE INDEX [GuiArticles_Name_Index] ON [GuiArticles]([Name]);
CREATE INDEX [GuiArticles_TenantID_Index] ON [GuiArticles]([TenantID]);
CREATE INDEX [GuiArticles_StockLocationID_Index] ON [GuiArticles]([StockLocationID]);

---------------------------------------------------

ALTER TABLE [GuiPacks] ADD COLUMN [TenantID] VARCHAR NOT NULL DEFAULT '';
ALTER TABLE [GuiPacks] ADD COLUMN [TenantDescription] NVARCHAR NOT NULL DEFAULT '';
ALTER TABLE [GuiPacks] ADD COLUMN [StockLocationID] VARCHAR NOT NULL DEFAULT '';
ALTER TABLE [GuiPacks] ADD COLUMN [StockLocationDescription] NVARCHAR NOT NULL DEFAULT '';

CREATE INDEX [GuiPacks_TenantID_Index] ON [GuiPacks]([TenantID]);
CREATE INDEX [GuiPacks_StockLocationID_Index] ON [GuiPacks]([StockLocationID]);

---------------------------------------------------

PRAGMA user_version = 2;

---------------------------------------------------
