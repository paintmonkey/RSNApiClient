﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNApiClient.Services
{
    public interface IWebService<T>
    {
        Task<List<T>> Get();
        void Post(List<T> input);
    } 

    public abstract class Service
    {
        public string BaseUrl { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }
        
        public RSNApiClient Client { get; private set; }

        protected Service(string url, string user, string password)
        {
            BaseUrl = url;
            User = user;
            Password = password;

            Console.WriteLine("Service created to {0}", url);
            Console.WriteLine("Authentication set for user {0}", user);

            Client = new RSNApiClient(url, user, password);
        }
    }
}