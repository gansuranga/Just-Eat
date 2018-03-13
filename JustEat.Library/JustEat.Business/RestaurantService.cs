// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestaurantService.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the RestaurantService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Business
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web.Script.Serialization;

    using JustEat.Business.Interfaces;
    using JustEat.Objects;

    /// <summary>
    /// The restaurant service.
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        /// <summary>
        /// Retrieve restaurant result.
        /// </summary>
        /// <param name="outCode">
        /// The out code.
        /// </param>
        /// <returns>
        /// The <see cref="RestaurantResult"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Return Exception APIS.com services fault or error.
        /// </exception>
        public RestaurantResult GetSearchResult(string outCode)
        {
            var request = (HttpWebRequest)WebRequest.CreateDefault(new Uri("https://public.je-apis.com/restaurants?q=" + outCode));
            request.Method = "GET";
            request.Accept = "application/json";

            request.Headers.Add(@"Accept-Tenant:uk");
            request.Headers.Add(@"Accept-Language:en-GB");
            request.Headers.Add(@"Authorization:Basic VGVjaFRlc3RBUEk6dXNlcjI=");

            request.Host = "public.je-apis.com";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    var js = new JavaScriptSerializer();
                    var objText = stream.ReadToEnd();
                    var objResponse = (RestaurantResult)js.Deserialize(objText, typeof(RestaurantResult));

                    return objResponse;
                }
            }
        }
    }
}
