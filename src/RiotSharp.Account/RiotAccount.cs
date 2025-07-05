using RiotSharp.Account.Endpoints;

namespace RiotSharp.Account
{
	/// <summary>
	/// Serves as the main entry point for the Account API.
	/// All endpoints will be accessed through this class.
	/// </summary>
	public class RiotAccount
	{
		public IAccountEndpoint Account { get; }

		public RiotAccount(IAccountEndpoint accont)
		{
			Account = accont ?? throw new ArgumentNullException(nameof(accont), "Account endpoint cannot be null.");

		}
		public class Builder
		{
			private IAccountEndpoint _account;
			// ... more endpoints

			public Builder UseAccountEndpoint(IAccountEndpoint endpoint)
			{
				_account = endpoint;
				return this;
			}

			// ... more WithXEndpoint methods

			public RiotAccount Build()
			{
				// Optionally validate all required endpoints are set
				return new RiotAccount(_account);
			}
		}
	}
}
