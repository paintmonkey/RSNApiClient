using System;

namespace RSNApiClient.Services
{
    public abstract class Service
    {
        public RSNApiClient client { get; private set; }

        protected Service(string url, string user, string password)
        {
            this.client = new RSNApiClient(url, user, password);
        }
    }
}
