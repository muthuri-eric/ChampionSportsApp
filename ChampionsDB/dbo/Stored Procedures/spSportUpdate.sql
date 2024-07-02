CREATE PROCEDURE [dbo].[spSportUpdate]
@SportId int,
@SportDescription nvarchar(20)
AS
begin
update dbo.Sport
set SportDescription = @SportDescription where SportId = @SportId
end
