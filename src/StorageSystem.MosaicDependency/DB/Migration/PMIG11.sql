---- Migration script to update the productive database schema from version 11 to 12 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrders] ADD COLUMN [OutputPoint] INT NOT NULL DEFAULT 0;
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [OutputPoint] INT NOT NULL DEFAULT 0;

---------------------------------------------------

PRAGMA user_version = 12;

---------------------------------------------------