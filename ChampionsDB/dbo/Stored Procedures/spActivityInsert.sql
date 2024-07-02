CREATE PROCEDURE [dbo].[spActivityInsert]
@TraineeId int,
@Description nvarchar(50),
@IsCompleted bit
AS
begin
insert into dbo.Activity(TraineeId, Description, IsCompleted)
values(@TraineeId, @Description, @IsCompleted)
end
