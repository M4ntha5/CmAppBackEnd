﻿using CmApp.Contracts.Entities;
using System.Threading.Tasks;

namespace CmApp.Contracts.Interfaces.Repositories
{
    public interface ISummaryRepository
    {
        Task<Summary> InsertSummary(Summary summary);
        Task<Summary> GetSummaryByCarId(int carId);
        Task DeleteCarSummary(int carId);
        Task UpdateCarSoldSummary(Summary summary);
        Task InsertTotalByCar(int summaryId, double total);
    }
}