CREATE PROCEDURE [dbo].[spTraineeInsert]
@StudentId int,
@SportEventId int,
@Accepted BIT,
@Attended bit
AS
begin
insert into dbo.Trainee(StudentId, SportEventId, Accepted, Attended)
values(@StudentId, @SportEventId, @Accepted, @Attended)
end
