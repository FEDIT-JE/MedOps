using System.Threading.Tasks;

namespace MedOps.Pages
{
    public partial class Login
    {

        private bool success;
        private string[] errors = new string[0];
        private bool isBusy = false;

        private string email = string.Empty;
        private string password = string.Empty;

        private bool isLoggedIn = false;
        private string message = string.Empty;

        private async Task LoginAsync()
        {
            isBusy = true;
            await Task.Delay(2500);
            if (email.Equals("test@test.com") && password == "Test.123")
            {
                isLoggedIn = true;
                message = "Welcome to MudBlazor Sample from AK, I hope you liked it";
            }
            else
            {
                isLoggedIn = false;
                message = "Invalid email or password";
            }
            isBusy = false;
        }
    }
}
