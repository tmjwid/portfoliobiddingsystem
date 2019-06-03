namespace BiddingSystem.Common
{
    public interface ICookieHelper
    {
        string Get(string key);

        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        void Set(string key, string value, int? expireTime);

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        void Remove(string key);

    }
}