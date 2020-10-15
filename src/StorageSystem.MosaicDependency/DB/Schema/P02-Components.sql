---- Basic Mosaic Components and their Configuration Values ----

CREATE TABLE [Components](
	[ID] INT NOT NULL PRIMARY KEY,
	[Type] NVARCHAR NOT NULL,
	[Assembly] NVARCHAR NOT NULL,
	[ClassName] NVARCHAR NOT NULL,
	[Description] NVARCHAR NOT NULL,
	[IsActive] BOOLEAN NOT NULL,
	[ConnectedComponentID] INT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ConnectedComponentID) REFERENCES Components(ID)
);

---------------------------------------------------------

CREATE TABLE [ConfigurationValues](
	[ComponentID] INT NOT NULL,
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NOT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	PRIMARY KEY(ComponentID, Name)
);

CREATE UNIQUE INDEX ConfigurationValues_ID_Index ON ConfigurationValues(ComponentID, Name);

---------------------------------------------------------

CREATE TABLE [ComponentDataValues](
	[ComponentID] INT NOT NULL,
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NOT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	PRIMARY KEY(ComponentID, Name)
);

CREATE UNIQUE INDEX ComponentDataValues_ID_Index ON ComponentDataValues(ComponentID, Name);

---------------------------------------------------------

INSERT OR REPLACE INTO Components(ID, Type, Assembly, ClassName, Description, IsActive, LastChange)
VALUES (1, 'Mosaic', '', '', 'The Mosaic Framework itself.', 1, datetime('now'));

---------------------------------------------------------