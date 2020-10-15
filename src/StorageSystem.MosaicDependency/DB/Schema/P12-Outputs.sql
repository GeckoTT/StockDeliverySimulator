 ---- Mosaic Outputs ----

CREATE TABLE [Outputs](
	[Number] INT NOT NULL PRIMARY KEY,
	[NumberInConveyorSystem] INT NOT NULL,
	[Name] NVARCHAR NOT NULL,
	[Description] NVARCHAR NOT NULL,
	[ExternalIdentifier] NVARCHAR NOT NULL,
	[AreSpecialPacksAllowed] BOOLEAN NOT NULL,
	[IsTrash] BOOLEAN NOT NULL,
	[IsDisabled] BOOLEAN NOT NULL,
	[LastChange] DATETIME NOT NULL
);

---------------------------------------------------