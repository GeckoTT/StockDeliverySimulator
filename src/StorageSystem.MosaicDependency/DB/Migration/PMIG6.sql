---- Migration script to update the productive database schema from version 6 to 7 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [OutputNumber] INT NOT NULL DEFAULT 0;

-- update order numbers
UPDATE [StockOutputOrderItemPacks] 
SET [OutputNumber] = (SELECT [OutputNumber] FROM [StockOutputOrders] 
WHERE [ID] = [StockOutputOrderItemPacks].[StockOutputOrderID] LIMIT 1);


---------------------------------------------------

PRAGMA user_version = 7;

---------------------------------------------------