
using System;
using Microsoft.Extensions.Configuration;

namespace samples.dependencyInjection
{
    public class SimpleKeyVault : ISecurityVault
    {
        private IConfiguration _configuration;

        public SimpleKeyVault(IConfigurationRoot configuration) {
            _configuration = configuration;
            if(String.IsNullOrEmpty(_configuration.GetSection("some-setting").Value))
                throw new Exception("Please add some-setting in appsettings.json.");            
        }

        public string GetKey(string keyName)
        {            
            return "mykey";
        }

        public string GetSecret(string secretName)
        {
            return "mysecret";
        }
    }
}