using RiotSharp.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticMasteryEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all masteries asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An MasteryListStatic object containing all masteries.</returns>
        Task<MasteryListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}