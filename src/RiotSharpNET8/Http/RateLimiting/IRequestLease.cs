namespace RiotSharpNET8.Http.RateLimiting;

/// <summary>
/// Interface for the RequestLease.
/// </summary>
public interface IRequestLease
{
	/// <summary>
	/// Indicates if the request was acquired.
	/// </summary>
	bool IsAcquired { get; set; }

	/// <summary>
	/// If the request was denied, a RetryAfter TimeSpan is set.
	/// </summary>
	TimeSpan? RetryAfter { get; set; }

	/// <summary>
	/// Indicates the type of rate limit this lease is for.
	/// </summary>
	RateLimitType RateLimitType { get; set; }

}

public enum RateLimitType
{
	/// <summary>
	/// The method rate limit type.
	/// </summary>
	Method,
	/// <summary>
	/// The app rate limit type.
	/// </summary>
	App,
	/// <summary>
	/// The service rate limit type. It is used when the request is denied due to an unknown limit.
	/// </summary>
	Service,

	/// <summary>
	/// Unknown reason
	/// </summary>
	Unknown
}