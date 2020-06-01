CREATE PROCEDURE [dbo].[GetOffersLessThanPrice]
	@Price decimal
AS
	SELECT * FROM Offers WHERE Price <= @Price;
GO