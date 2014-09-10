namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Participant's role (Match API).
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Corresponds to duo lane.
        /// </summary>
        Duo,

        /// <summary>
        /// Corresponds to no role.
        /// </summary>
        None,

        /// <summary>
        /// Corresponds to solo lanes (mid or top).
        /// </summary>
        Solo,

        /// <summary>
        /// Corresponds to ad carry.
        /// </summary>
        DuoCarry,

        /// <summary>
        /// Corresponds to support.
        /// </summary>
        DuoSupport
    }

    static class RoleExtension
    {
        public static string ToCustomString(this Role role)
        {
            switch (role)
            {
                case Role.Duo:
                    return "DUO";
                case Role.None:
                    return "NONE";
                case Role.Solo:
                    return "SOLO";
                case Role.DuoCarry:
                    return "DUO_CARRY";
                case Role.DuoSupport:
                    return "DUO_SUPPORT";
                default:
                    return string.Empty;
            }
        }
    }
}
