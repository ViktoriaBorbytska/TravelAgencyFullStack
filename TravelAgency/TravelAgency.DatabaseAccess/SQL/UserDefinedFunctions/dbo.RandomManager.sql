CREATE VIEW dbo.GetNewID
AS
SELECT NewId() AS [NewID]
GO

CREATE FUNCTION [dbo].[RandomManager]
(
)
RETURNS INT
AS
BEGIN
	DECLARE @managerId int;
	
	SELECT TOP 1 @managerId = UserId FROM Managers ORDER BY (SELECT [NewId] FROM GetNewID);

	RETURN @managerId;
END
