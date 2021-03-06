﻿using RestSharp;
using RestSharp.Authenticators;
using TradeUnionCommittee.DataAnalysis.Service.Models;

namespace TradeUnionCommittee.DataAnalysis.Service
{
    public class DataAnalysisClient : RestClient
    {
        public DataAnalysisClient(DataAnalysisConnection connection) : base(connection.Url)
        {
            if (connection.UseBasicAuthentication)
                Authenticator = new HttpBasicAuthenticator(connection.UserName, connection.Password);
            
            if (connection.IgnoreCertificateValidation)
                RemoteCertificateValidationCallback = ((sender, certificate, chain, errors) => true);
        }
    }
}