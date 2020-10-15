
---- Migration script to update the productive database schema from version 14 to 15 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItems] ADD COLUMN [ArticleName] NVARCHAR NOT NULL DEFAULT '';

---------------------------------------------------

PRAGMA user_version = 15;

---------------------------------------------------