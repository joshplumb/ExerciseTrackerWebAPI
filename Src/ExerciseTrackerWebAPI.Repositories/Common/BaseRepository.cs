using Microsoft.Extensions.Configuration;

namespace ExerciseTrackerWebAPI.Repositories.Common
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;
        protected readonly string _dbconnectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbconnectionString = GetConnectionsString();
        }

        private string? GetConnectionsString()
        {
            return _configuration.GetConnectionString("LocalConnection");
        }
    }
}
