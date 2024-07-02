CREATE PROCEDURE [dbo].[spSportEventGetById]
@SportEventId int
AS
begin
	SELECT * from dbo.SportEvent where SportEventId = @SportEventId
end
