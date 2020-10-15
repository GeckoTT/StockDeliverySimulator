
---- Migration script to update the history database schema from version 11 to 12 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItems] ADD COLUMN [SingleBatchNumber] BOOLEAN NOT NULL DEFAULT 0;

---------------------------------------------------

PRAGMA user_version = 12;

---------------------------------------------------