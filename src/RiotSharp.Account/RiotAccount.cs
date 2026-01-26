using RiotSharp.Account.Endpoints;

namespace RiotSharp.Account
{
	/// <summary>
	/// Serves as the main entry point for the Account API.
	/// All endpoints will be accessed through this class.
	/// </summary>
	public class RiotAccount
	{
		public IAccountEndpoint? Account { get; }

        /// <summary>
        /// Private constructor to enforce the use of the Builder pattern.
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private RiotAccount(IAccountEndpoint? account)
		{
            // Since it does not make sense to have an Account API without an Account endpoint, we enforce that it is not null.
            Account = account ?? throw new ArgumentNullException(nameof(account), "Account endpoint cannot be null.");
		}

		/// <summary>
		/// Provides a builder for configuring and creating instances of the RiotAccount class.
		/// </summary>
		/// <remarks>Use the Builder class to configure endpoints and construct a RiotAccount instance.
		public class Builder
		{
			private IAccountEndpoint? _account;

			public Builder UseAccountEndpoint(IAccountEndpoint? endpoint)
			{
				_account = endpoint;
				return this;
			}

            /// <summary>
            /// Finalizes the configuration and constructs a RiotAccount instance.
            /// </summary>
            /// <returns>The RiotAccount instance to be used.</returns>
            public RiotAccount Build()
			{
				// Optionally validate all required endpoints are set
				return new RiotAccount(_account);
			}
		}
	}
}
