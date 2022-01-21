using System.Threading.Tasks;

namespace DietAnalyzer.Services.Utilities
{
    /// <summary>
    /// 
    /// A utility service used to fill new user accounts with data examples
    /// See also Data -> DataSeeder for more discussion
    ///
    /// </summary>
    public interface IExampleDataService
    {
        /// <summary>
        /// Call this method to create example data and link it to the registered user's account
        /// </summary>
        /// <param name="userId"> is the registered user ID</param>
        Task InsertExampleDataAsync(string userId);

        /// <summary>
        /// Call this method to create example data and link it to the registered user's account
        /// </summary>
        /// <param name="userId"> is the registered user ID</param>
        void InsertExampleData(string userId);
    }
}
