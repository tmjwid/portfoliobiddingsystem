using System;
using Microsoft.AspNetCore.Http;

namespace BiddingSystem.Common
{
    public class CookieHelper : ICookieHelper
    {
        IHttpContextAccessor httpContextAccessor;

        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string Get(string key)
        {
            return httpContextAccessor.HttpContext.Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions(){SameSite = SameSiteMode.Strict, Secure = true};
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}