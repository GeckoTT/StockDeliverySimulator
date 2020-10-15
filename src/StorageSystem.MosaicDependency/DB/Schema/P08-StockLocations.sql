 ---- Mosaic Stock Locations ----

CREATE TABLE [StockLocations](
	[ID] VARCHAR NOT NULL, 
	[ComponentID] INT NOT NULL, 
	[Description] NVARCHAR NOT NULL, 		
	[TotalCapacity] INT NOT NULL, 
	[UsedCapacity] INT NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [ComponentID])
);

CREATE UNIQUE INDEX [StockLocations_ID_Index] ON [StockLocations]([ID], [ComponentID]);

---------------------------------------------------
	