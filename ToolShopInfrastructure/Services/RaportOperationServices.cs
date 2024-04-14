using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.DataBase;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopInfrastructure.Services
{
    public class RaportOperationServices:IRaportOperationServices
    {
        private readonly ToolShopDbContext _dbContext;

        public RaportOperationServices(ToolShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> AddRaportAsync(OperationRaport raport)
            => await Result.Try(() => AddRaport(raport),
                ex=> new Error(ex.Message));
       

        public async Task<Result> DeleteRaportAsync(OperationRaport raport)
            => await Result.Try(() => DeleteRaport(raport),
                ex => new Error(ex.Message));

        private async Task AddRaport(OperationRaport raport)
        {
            raport.Id = default;
            await _dbContext.OperationRaports.AddAsync(raport);
            await _dbContext.SaveChangesAsync();
        }

        private async Task DeleteRaport(OperationRaport raport)
        {
            _dbContext.OperationRaports.Remove(raport);
            await _dbContext.SaveChangesAsync();
        }
    }
}
