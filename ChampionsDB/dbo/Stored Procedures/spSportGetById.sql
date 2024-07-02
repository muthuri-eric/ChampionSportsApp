CREATE PROCEDURE [dbo].[spSportGetById]
@SportId int
AS
begin
	SELECT * from dbo.Sport where SportId = @SportId
end