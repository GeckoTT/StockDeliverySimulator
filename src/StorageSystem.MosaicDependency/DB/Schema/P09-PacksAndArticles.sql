---- Mosaic Packs and Articles ----

CREATE VIEW [PackAndArticles] AS 
SELECT 	RobotPacks.ID, 
		RobotPacks.RobotArticleID, 
		RobotPacks.RobotArticleCode,
		RobotPacks.ComponentID,  
		RobotPacks.BatchNumber,
		RobotPacks.DeliveryNumber,
		RobotPacks.ExpiryDate,
		RobotPacks.ExternalID,
		RobotPacks.IsInFridge,
		RobotPacks.Shape,
		RobotPacks.SubItemQuantity,
		RobotPacks.ScanCode,
		RobotPacks.StockInDate,
		RobotPacks.Depth,
		RobotPacks.Height,
		RobotPacks.Width,
		RobotPacks.StockLocationID, 
	    RobotPacks.TenantID,
	    RobotPacks.MachineLocation, 
		RobotPacks.IsAvailable,
		RobotPacks.IsBlocked,
		RobotPacks.IsOnline,
		RobotPacks.LastChange,
		RobotArticles.Name,
		RobotArticles.Code,
		RobotArticles.DosageForm,
		RobotArticles.PackagingUnit,
		RobotArticles.RequiresFridge,
		RobotArticles.MaxSubItemQuantity,
		StockLocations.Description AS StockLocationDescription,
		Tenants.Description AS TenantDescription

FROM RobotPacks 
LEFT JOIN RobotArticles 
ON RobotPacks.RobotArticleID=RobotArticles.ID AND RobotPacks.ComponentID=RobotArticles.ComponentID
LEFT JOIN StockLocations 
ON RobotPacks.StockLocationID=StockLocations.ID AND RobotPacks.ComponentID=StockLocations.ComponentID
LEFT JOIN Tenants 
ON RobotPacks.TenantID=Tenants.ID AND RobotPacks.ComponentID=Tenants.ComponentID;
