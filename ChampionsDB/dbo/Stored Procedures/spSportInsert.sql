CREATE PROCEDURE [dbo].[spSportInsert]
	@SportDescription nvarchar(20)
AS
begin
	insert into dbo.Sport(SportDescription)
	values(@SportDescription)
end
