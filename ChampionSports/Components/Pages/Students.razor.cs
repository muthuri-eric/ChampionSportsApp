using ChampionsDbHelper.Data;
using ChampionsDbHelper.Models;
using ChampionSports.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace ChampionSports.Components.Pages;
public partial class Students
{
    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();
    private Student student = new();
    private IEnumerable<Student>? students;
    private IEnumerable<GradeLevel>? gradeLevels;
    private Student? updatedStudent = new();
    private int studentId;
    private string? Message => identityErrors is null ? null : $"Error: {string.Join(", ", identityErrors.Select(error => error.Description))}";
    protected async override Task OnInitializedAsync()
    {
        students = await studentData.GetAllStudentDataAsync();
        gradeLevels = await gradeLevelData.GetAllGradeLevelDataAsync();
    }
    private async Task AddStudent()
    {
        await studentData.SaveStudentDataAsync(student);
    }
    public async Task UpdateTrainer(int id, string userId)
    {
        updatedStudent = await studentData.GetStudentByIdAsync(id);
        updatedStudent.Id = userId;
        await studentData.UpdateStudentDataAsync(updatedStudent);
    }
    private IEnumerable<IdentityError>? identityErrors;
    public async Task RegisterUser(EditContext editContext)
    {
        var user = CreateUser();

        await UserStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        var emailStore = GetEmailStore();
        await emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
        user.EmailConfirmed = true;
        var result = await UserManager.CreateAsync(user, Input.Password);

        if (!result.Succeeded)
        {
            identityErrors = result.Errors;
            return;
        }
        else
        {
            await UserManager.AddToRoleAsync(user, "Trainee");

            await UpdateTrainer(Input.Id, user.Id);
        }

        //Logger.LogInformation("User created a new account with password.");

        var userId = await UserManager.GetUserIdAsync(user);
        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
    }

    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
        }
    }

    private IUserEmailStore<ApplicationUser> GetEmailStore()
    {
        if (!UserManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<ApplicationUser>)UserStore;
    }
}