﻿using AppGameTrueFalse.Resources;

namespace AppGameTrueFalse
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();
        // git hub
        //gio t up len ben t, xong lay xuong ben m
        //dau tien la commit 2 dong nay len github
        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}