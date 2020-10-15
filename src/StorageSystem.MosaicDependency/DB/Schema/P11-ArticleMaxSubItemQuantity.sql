 ---- Sub Item Quantity Cache for Articles ----

CREATE TABLE [ArticleMaxSubItemQuantitys](
	[ID] NVARCHAR NOT NULL, 	
	[TenantID] VARCHAR NOT NULL,
	[MaxSubItemQuantity] INT NOT NULL,
	[LastChange] DATETIME NOT NULL,
	PRIMARY KEY([ID], [TenantID])
);

CREATE UNIQUE INDEX [ArticleMaxSubItemQuantitys_ID_Index] ON [ArticleMaxSubItemQuantitys]([ID], [TenantID]);

---------------------------------------------------
