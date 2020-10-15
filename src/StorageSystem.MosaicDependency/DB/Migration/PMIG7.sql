---- Migration script to update the productive database schema from version 7 to 8 ----

---------------------------------------------------

DELETE FROM [GuiPacks];

DROP INDEX GuiPacks_Code_Index;
DROP INDEX GuiPacks_Name_Index;
DROP INDEX GuiPacks_ID_Index;
DROP TABLE [GuiPacks];

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
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY(ID, ComponentID)
);

CREATE UNIQUE INDEX GuiPacks_ID_Index ON GuiPacks(ID, ComponentID);
CREATE INDEX GuiPacks_Code_Index ON GuiPacks(ArticleCode);
CREATE INDEX GuiPacks_Name_Index ON GuiPacks(ArticleName);

---------------------------------------------------

PRAGMA user_version = 8;

---------------------------------------------------