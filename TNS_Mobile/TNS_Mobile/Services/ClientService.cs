using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TNS_Mobile.Services
{
    public class ClientService
    {
        public const string APIUrl = "http://localhost:62623/";
        private static ClientService instanse;
  
        private ClientService() { }
        public static ClientService Instance => instanse ?? (instanse = new ClientService());
        public HttpClient HttpClient { get; set; }
    }
}
