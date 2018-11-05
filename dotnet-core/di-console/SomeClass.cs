using System;

namespace samples.dependencyInjection
{
    public class SomeClass
    {
        private ISecurityVault _securityVault;
        public SomeClass(ISecurityVault securityVault) {
            _securityVault = securityVault;
            Console.WriteLine($"vaultType={_securityVault.ToString()}");
        }
    }
}