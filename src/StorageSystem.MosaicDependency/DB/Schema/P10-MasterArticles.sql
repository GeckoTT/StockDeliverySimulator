 ---- Master Articles ----

CREATE TABLE [MasterArticles](
	[ID] INT NOT NULL, 	
	[TenantID] VARCHAR NOT NULL,
	[Code] NVARCHAR NOT NULL, 	
	[Name] NVARCHAR NOT NULL,	
	[DosageForm] NVARCHAR NOT NULL, 
	[PackagingUnit] NVARCHAR NOT NULL, 
	[RequiresFridge] BOOLEAN NOT NULL, 
	[MaxSubItemQuantity] INT NOT NULL,
	[StockLocationID] VARCHAR NOT NULL, 
	[MachineLocation] VARCHAR NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [TenantID])
);

CREATE UNIQUE INDEX [MasterArticles_ID_Index] ON [MasterArticles]([ID], [TenantID]);
CREATE INDEX [MasterArticles_Code_Index] ON [MasterArticles]([Code]);
CREATE INDEX [MasterArticles_Name_Index] ON [MasterArticles]([Name]);
CREATE INDEX [MasterArticles_StockLocationID_Index] ON [MasterArticles]([StockLocationID]);

---------------------------------------------------