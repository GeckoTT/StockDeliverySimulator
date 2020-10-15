---- Migration script to update the history database schema from version 6 to 7 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrders] ADD COLUMN [OutputPoint] INT NOT NULL DEFAULT 0;
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [OutputPoint] INT NOT NULL DEFAULT 0;

---------------------------------------------------

PRAGMA user_version = 7;

---------------------------------------------------