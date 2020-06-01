CREATE PROCEDURE [dbo].[AddOfferToOrder]
	@OfferId int,
	@UserId int
AS
	INSERT INTO Orders (UserId, OfferId) values (@UserId, @OfferId);
GO
