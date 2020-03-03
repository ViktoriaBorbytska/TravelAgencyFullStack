CREATE TRIGGER Orders_insert
ON Orders
After insert
AS
BEGIN
	Update Orders set ManagerId = dbo.RandomManager() where id = (select id from inserted);
END
