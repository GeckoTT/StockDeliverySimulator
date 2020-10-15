---- Migration script to update the productive database schema from version 9 to 10 ----

---------------------------------------------------

-- extend table
ALTER TABLE [Articles] ADD COLUMN [IsMasterArticle] BOOLEAN NOT NULL DEFAULT 0;

---------------------------------------------------

-- update content
UPDATE [Articles] SET [IsMasterArticle] = 1 WHERE [ComponentID] = 1;

---------------------------------------------------

PRAGMA user_version = 10;

---------------------------------------------------
