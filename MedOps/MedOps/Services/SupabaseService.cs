using Supabase.Gotrue;

namespace MedOps.Services
{
    public class SupabaseService
    {
        private readonly Supabase.Client _client;

        public SupabaseService()
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true
            };

            _client = new Supabase.Client(
                "https://your-project.supabase.co",   // 🔑 Replace with your Supabase URL
                "your-supabase-anon-key",             // 🔑 Replace with your anon key
                options
            );

            _client.InitializeAsync().Wait();  // You can use `await` in async constructor logic
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            var response = await _client.Auth.SignIn(email, password);
            return response?.User != null;
        }

        public async Task SignOutAsync()
        {
            await _client.Auth.SignOut();
        }

        public async Task InitializeAsync()
        {
            await _client.InitializeAsync();
        }


        public Session CurrentSession => _client.Auth.CurrentSession;
        public User CurrentUser => _client.Auth.CurrentUser;
    }
}
