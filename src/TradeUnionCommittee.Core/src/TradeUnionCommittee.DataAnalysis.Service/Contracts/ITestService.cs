﻿using System.Collections.Generic;
using TradeUnionCommittee.DataAnalysis.Service.Models;

namespace TradeUnionCommittee.DataAnalysis.Service.Contracts
{
    public interface ITestService
    {
        bool HealthCheck();
        IEnumerable<TestModel> TestPostJson();
        string TestPostCsv();

        Dictionary<string, bool> RunAllTasks();
    }
}