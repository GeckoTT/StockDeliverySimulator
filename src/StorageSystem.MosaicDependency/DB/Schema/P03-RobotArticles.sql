 ---- Mosaic Articles ----

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

CREATE UNIQUE INDEX [Articles_ID_Index] ON [RobotArticles]([ID], [ComponentID]);
CREATE INDEX [Articles_Code_Index] ON [RobotArticles]([Code]);
CREATE INDEX [Articles_Name_Index] ON [RobotArticles]([Name]);

---------------------------------------------------


