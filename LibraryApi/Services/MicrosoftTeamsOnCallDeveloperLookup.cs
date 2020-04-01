using LibraryApi.Controllers;
using LibraryApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class MicrosoftTeamsOnCallDeveloperLookup : ILookupOnCallDevelopers
    {
        IDistributedCache Cache;

        public MicrosoftTeamsOnCallDeveloperLookup(IDistributedCache cache)
        {
            Cache = cache;
        }

        public async Task<OnCallDeveloperResponse> GetOnCallDeveloper()
        {
            var email = await Cache.GetAsync("email");
            string emailAddress = null;
            if(email == null)
            {
                //Call Microsoft Teams API, get the email address.
                var emailToSave = $"bob-{DateTime.Now.ToLongTimeString()}@qwer.com";
                var encodeEmail = Encoding.UTF8.GetBytes(emailToSave);
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddSeconds(15));
                await Cache.SetAsync("email", encodeEmail, options);
                //Add it to the cache with an expiration
                //return that email address.
                emailAddress = emailToSave;
            }
            else
            {
                emailAddress = Encoding.UTF8.GetString(email);
            }

            return new OnCallDeveloperResponse { Email = emailAddress };
        }
    }
}
