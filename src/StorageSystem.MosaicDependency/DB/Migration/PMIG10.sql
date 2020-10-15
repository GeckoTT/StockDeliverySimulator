---- Migration script to update the productive database schema from version 9 to 10 ----

---- drop gui data model tables ----

DROP TABLE GuiPacks;
DROP TABLE GuiArticles;

---- removed obsolete haschanged flags ----

DROP VIEW [PackAndArticles];

CREATE VIEW [PackAndArticles] AS 
SELECT 	Packs.ID, 
		Packs.ArticleID, 
		Packs.ArticleCode,
		Packs.ComponentID,  
		Packs.BatchNumber,
		Packs.DeliveryNumber,
		Packs.ExpiryDate,
		Packs.ExternalID,
		Packs.IsInFridge,
		Packs.Shape,
		Packs.SubItemQuantity,
		Packs.ScanCode,
		Packs.StockInDate,
		Packs.Depth,
		Packs.Height,
		Packs.Width,
		Packs.IsAvailable,
		Packs.IsBlocked,
		Packs.LastChange,
		Articles.Name,
		Articles.Code,
		Articles.DosageForm,
		Articles.PackagingUnit,
		Articles.RequiresFridge,
		Articles.MaxSubItemQuantity,
		Components.Description
FROM Packs LEFT JOIN Articles 
ON Packs.ArticleID=Articles.ID AND Packs.ComponentID=Articles.ComponentID
LEFT JOIN Components ON Packs.ComponentID=Components.ID;

---------------------------------------------------

CREATE TABLE [PACKS_BACKUP](
	[ID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,	
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL, 
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL, 
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL
);

CREATE TABLE [PACKATTRIBUTES_BACKUP](
	[PackID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL
);

CREATE TABLE [ARTICLES_BACKUP](
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
	[IsMasterArticle] BOOLEAN NOT NULL,
	[LastChange] DATETIME NOT NULL
);

CREATE TABLE [ARTICLEATTRIBUTES_BACKUP](
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ArticleID, ComponentID) REFERENCES Articles(ID, ComponentID),
	PRIMARY KEY(ArticleID, ComponentID, Name)
);

---------------------------------------------------

INSERT INTO ARTICLES_BACKUP(ID, ComponentID, Code, Name, DosageForm, PackagingUnit,
						    RequiresFridge, MaxSubItemQuantity, IsAvailable, IsBlocked, 
							IsMasterArticle, LastChange) 
SELECT ID, ComponentID, Code, Name, DosageForm, PackagingUnit,
	   RequiresFridge, MaxSubItemQuantity, IsAvailable, IsBlocked, 
	   IsMasterArticle, LastChange 
FROM Articles;

INSERT INTO PACKS_BACKUP(ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
						 ExpiryDate, ExternalID, IsInFridge, Shape, SubItemQuantity, ScanCode, 
						 StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, LastChange) 
SELECT ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, IsInFridge, Shape, SubItemQuantity, ScanCode, 
	   StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, LastChange 
FROM Packs;

INSERT INTO ARTICLEATTRIBUTES_BACKUP(ArticleID, ComponentID, Name, Value, LastChange) 
SELECT ArticleID, ComponentID, Name, Value, LastChange 
FROM ArticleAttributes;

INSERT INTO PACKATTRIBUTES_BACKUP(PackID, ArticleID, ComponentID, Name, Value, LastChange) 
SELECT PackID, ArticleID, ComponentID, Name, Value, LastChange 
FROM PackAttributes;

---------------------------------------------------

DROP TABLE PackAttributes;
DROP TABLE Packs;
DROP TABLE ArticleAttributes;
DROP TABLE Articles;

---------------------------------------------------

CREATE TABLE [Articles](
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
	[IsMasterArticle] BOOLEAN NOT NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ComponentID) REFERENCES Components(ID),
	PRIMARY KEY(ID, ComponentID)
);

CREATE UNIQUE INDEX Articles_ID_Index ON Articles(ID, ComponentID);
CREATE INDEX Articles_Code_Index ON Articles(Code);
CREATE INDEX Articles_Name_Index ON Articles(Name);

CREATE TABLE [ArticleAttributes](
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ArticleID, ComponentID) REFERENCES Articles(ID, ComponentID),
	PRIMARY KEY(ArticleID, ComponentID, Name)
);

CREATE UNIQUE INDEX ArticleAttributes_ID_Index ON ArticleAttributes(ArticleID, ComponentID, Name);

CREATE TABLE [Packs] (
	[ID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,		
	[ArticleCode] NVARCHAR NOT NULL,	
	[BatchNumber] NVARCHAR NOT NULL, 
	[DeliveryNumber] NVARCHAR NULL, 
	[ExpiryDate] DATETIME NOT NULL, 
	[ExternalID] NVARCHAR NOT NULL, 
	[IsInFridge] BOOLEAN NOT NULL, 
	[Shape] NVARCHAR NOT NULL, 
	[SubItemQuantity] INT NOT NULL, 
	[ScanCode] NVARCHAR NOT NULL, 
	[StockInDate] DATETIME NOT NULL, 
	[Depth] INT NOT NULL,
	[Height] INT NOT NULL,
	[Width] INT NOT NULL, 
	[IsAvailable] BOOLEAN NOT NULL, 
	[IsBlocked] BOOLEAN NOT NULL, 
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(ArticleID, ComponentID) REFERENCES Articles(ID, ComponentID),
	PRIMARY KEY(ID, ArticleID, ComponentID)
);

CREATE UNIQUE INDEX Packs_ID_Index ON Packs(ID, ArticleID, ComponentID);
CREATE INDEX Packs_ArticleCode_Index ON Packs(ArticleCode);
CREATE INDEX Packs_BatchNumber_Index ON Packs(BatchNumber);
CREATE INDEX Packs_ExternalID_Index ON Packs(ExternalID);

CREATE TABLE [PackAttributes](
	[PackID] INT NOT NULL,
	[ArticleID] INT NOT NULL,
	[ComponentID] INT NOT NULL,	
	[Name] NVARCHAR NOT NULL,
	[Value] NVARCHAR NULL,
	[LastChange] DATETIME NOT NULL,
	FOREIGN KEY(PackID, ArticleID, ComponentID) REFERENCES Packs(ID, ArticleID, ComponentID),
	PRIMARY KEY(PackID, ArticleID, ComponentID, Name)
);

CREATE UNIQUE INDEX PackAttributes_ID_Index ON PackAttributes(PackID, ArticleID, ComponentID, Name);

---------------------------------------------------

INSERT INTO Articles(ID, ComponentID, Code, Name, DosageForm, PackagingUnit,
					 RequiresFridge, MaxSubItemQuantity, IsAvailable, IsBlocked, 
					 IsMasterArticle, LastChange) 
SELECT ID, ComponentID, Code, Name, DosageForm, PackagingUnit,
	   RequiresFridge, MaxSubItemQuantity, IsAvailable, IsBlocked, 
	   IsMasterArticle, LastChange 
FROM ARTICLES_BACKUP;

INSERT INTO Packs(ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
				  ExpiryDate, ExternalID, IsInFridge, Shape, SubItemQuantity, ScanCode, 
				  StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, LastChange) 
SELECT ID, ArticleID, ComponentID, ArticleCode, BatchNumber, DeliveryNumber,
	   ExpiryDate, ExternalID, IsInFridge, Shape, SubItemQuantity, ScanCode, 
	   StockInDate, Depth, Height, Width, IsAvailable, IsBlocked, LastChange 
FROM PACKS_BACKUP;

INSERT INTO ArticleAttributes(ArticleID, ComponentID, Name, Value, LastChange) 
SELECT ArticleID, ComponentID, Name, Value, LastChange 
FROM ARTICLEATTRIBUTES_BACKUP;

INSERT INTO PackAttributes(PackID, ArticleID, ComponentID, Name, Value, LastChange) 
SELECT PackID, ArticleID, ComponentID, Name, Value, LastChange 
FROM PACKATTRIBUTES_BACKUP;

---------------------------------------------------

DROP TABLE PACKATTRIBUTES_BACKUP;
DROP TABLE PACKS_BACKUP;
DROP TABLE ARTICLEATTRIBUTES_BACKUP;
DROP TABLE ARTICLES_BACKUP;

---------------------------------------------------

PRAGMA user_version = 11;

---------------------------------------------------
