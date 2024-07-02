using ChampionsDbHelper.Models;
using ChampionSports.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace ChampionSports.Components.Pages;
public partial class Trainers
{
    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = new();

    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }

    private string? Message => identityErrors is null ? null : $"Error: {string.Join(", ", identityErrors.Select(error => error.Description))}";
    private Trainer trainer = new();
    private Trainer? updatedTrainer = new();
    private int trainerId;
    public bool showModal = false;

    private IEnumerable<Trainer> trainers;
    protected override async Task OnInitializedAsync()
    {
        trainers = await trainerData.GetAllTrainerDataAsync();

    }
    private async Task AddTrainer()
    {
        await trainerData.SaveTrainerDataAsync(trainer);
    }
    private IEnumerable<IdentityError>? identityErrors;

    public async Task UpdateTrainer(int id, string userId)
    {
        updatedTrainer = await trainerData.GetTrainerByIdAsync(id);
        updatedTrainer.Id = userId;
        await trainerData.UpdateTrainerDataAsync(updatedTrainer);
    }

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
            await UserManager.AddToRoleAsync(user, "Trainer");
            await UpdateTrainer(Input.Id, user.Id);
        }

        //Logger.LogInformation("User created a new account with password.");

        var userId = await UserManager.GetUserIdAsync(user);
        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = NavigationManager.GetUriWithQueryParameters(
            NavigationManager.ToAbsoluteUri("Account/ConfirmEmail").AbsoluteUri,
            new Dictionary<string, object?> { ["userId"] = userId, ["code"] = code, ["returnUrl"] = ReturnUrl });
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