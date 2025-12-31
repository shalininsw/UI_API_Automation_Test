using OpenQA.Selenium;
using Ui.Tests.Base;

namespace Ui.Tests.Utilities
{
    public static class ScreenshotUtils
    {
        /// <summary>
        /// Capture screenshot as Base64 string (thread-safe)
        /// </summary>
        public static string CaptureScreenshotBase64(string testName)
        {
            IWebDriver driver = WebDriverFactory.GetDriver();
            if (driver == null) return null;

            return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        }

    }
}