using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticProfileIconEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of profile icons asynchronously
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A ProfileIconListStatic object containing all runes.</returns>
        Task<ProfileIconListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}