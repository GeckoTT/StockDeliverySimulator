---- Migration script to update the productive database schema from version 4 to 5 ----

--------------------------------------------------------------------------

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
		Packs.HasChanged,
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

-----------------------------------------------------

PRAGMA user_version = 5;

-----------------------------------------------------