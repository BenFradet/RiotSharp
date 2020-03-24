namespace RiotSharp.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The IStatic Endpoint Provider
    /// </summary>
    public interface IStaticEndpointProvider
    {
        /// <typeparam name="TStaticEndpoint">Type of Endpoint to receive</typeparam>
        TStaticEndpoint GetEndpoint<TStaticEndpoint>() where TStaticEndpoint : IStaticEndpoint;
    }
}
