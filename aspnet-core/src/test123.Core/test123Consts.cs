using test123.Debugging;

namespace test123
{
    public class test123Consts
    {
        public const string LocalizationSourceName = "test123";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "92b837a5c9984c3d912296f48a31fc5e";
    }
}
