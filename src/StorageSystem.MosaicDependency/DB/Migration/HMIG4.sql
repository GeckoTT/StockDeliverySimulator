---- Migration script to update the history database schema from version 4 to 5 ----

---------------------------------------------------

-- extend table
ALTER TABLE [StockOutputOrderItemPacks] ADD COLUMN [OutputNumber] INT NOT NULL DEFAULT 0;

-- update order numbers
UPDATE [StockOutputOrderItemPacks] 
SET [OutputNumber] = (SELECT [OutputNumber] FROM [StockOutputOrders] 
WHERE [ID] = [StockOutputOrderItemPacks].[StockOutputOrderID] AND [HistoryDate] = [StockOutputOrderItemPacks].[HistoryDate] LIMIT 1);

---------------------------------------------------

PRAGMA user_version = 5;

---------------------------------------------------

