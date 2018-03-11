namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticEndpointProvider
    {
        /// <typeparam name="TStaticEndpoint">Type of Endpoint to receive</typeparam>
        TStaticEndpoint GetEndpoint<TStaticEndpoint>() where TStaticEndpoint : IStaticEndpoint;
    }
}