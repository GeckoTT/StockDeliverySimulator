 ---- Mosaic Tenants ----
 
CREATE TABLE [Tenants](
	[ID] VARCHAR NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Description] NVARCHAR NOT NULL, 	
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [ComponentID])
);

CREATE UNIQUE INDEX [Tenants_ID_Index] ON [Tenants]([ID], [ComponentID]);

---------------------------------------------------