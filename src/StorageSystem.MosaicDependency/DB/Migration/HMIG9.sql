
---- Migration script to update the history database schema from version 9 to 10 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItems] ADD COLUMN [ArticleName] NVARCHAR NOT NULL DEFAULT '';

---------------------------------------------------

PRAGMA user_version = 10;

---------------------------------------------------