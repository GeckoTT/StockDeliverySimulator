 ---- PIS Articles ----
 
CREATE TABLE [PisArticles](
	[ID] INT NOT NULL PRIMARY KEY,
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
	FOREIGN KEY(ParentPisArticleID) REFERENCES PisArticles(ID)
);

CREATE UNIQUE INDEX [PisArticles_ID_Index] ON [PisArticles]([ID], [TenantID]);
CREATE INDEX [PisArticles_Code_Index] ON [PisArticles]([Code]);
CREATE INDEX [PisArticles_Name_Index] ON [PisArticles]([Name]);
CREATE INDEX [PisArticles_StockLocationID_Index] ON [PisArticles]([StockLocationID]);


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

---------------------------------------------------