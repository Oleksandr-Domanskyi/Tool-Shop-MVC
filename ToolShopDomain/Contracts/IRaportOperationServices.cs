using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Contracts;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopInfrastructure.Services
{
    public interface IRaportOperationServices:IService
    {
        Task<Result> AddRaportAsync(OperationRaport raport);
        Task<Result> DeleteRaportAsync(OperationRaport raport);
    }
}
