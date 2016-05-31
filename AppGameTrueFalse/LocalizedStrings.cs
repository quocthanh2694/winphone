using AppGameTrueFalse.Resources;

namespace AppGameTrueFalse
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();
        // git hub
        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}