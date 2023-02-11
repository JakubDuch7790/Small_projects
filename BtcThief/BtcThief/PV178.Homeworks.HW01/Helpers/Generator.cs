using System.IO;
using System.Net;

namespace PV178.Homeworks.HW01.Helpers
{
    public static class Generator
    {
        private const string Url = "http://generatorMacakM.azurewebsites.net/api/HW01";

        /// <summary>
        /// Returns random name.
        /// </summary>
        /// <returns>Name</returns>
        public static string GetName()
        {
            var request = WebRequest.Create($"{Url}/Name");

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd().Replace("\"", "");
                        }
            }
            catch (WebException) { }
            return "Martin Macák";
        }

        /// <summary>
        /// Returns random IP address
        /// </summary>
        /// <returns>IP</returns>
        public static string GetIp()
        {
            var request = WebRequest.Create($"{Url}/IP");

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd().Replace("\"", "");
                        }
            }
            catch (WebException) { }
            return "169.220.58.50";
        }

        /// <summary>
        /// Returns random BTC address
        /// </summary>
        /// <returns>BTC address</returns>
        public static string GetBtcAddress()
        {
            var request = WebRequest.Create($"{Url}/BTC");

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd().Replace("\"", "");
                        }
            }
            catch (WebException) { }
            return "1HgcjDJEwe6KBTnEoXURL6UNscdpw9Vehm";
        }

        /// <summary>
        /// Returns random password
        /// </summary>
        /// <returns>Password</returns>
        public static string GetPassword()
        {
            var request = WebRequest.Create($"{Url}/Password");

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd().Replace("\"", "");
                        }
            }
            catch (WebException) { }
            return "bnTZ28AFZ";
        }
    }
}
