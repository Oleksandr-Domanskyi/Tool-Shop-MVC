using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Repositories;

namespace ToolShopInfrastructure.Services
{
    public class EntityService<EntityType>: IEntityService<EntityType> where EntityType : Entity<int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<List<EntityType>>> _GetListAsync()
        {
            return await Result.Try(async Task<List<EntityType>> () =>
                await _unitOfWork.Repository<EntityType>().ListAsync(),
                ex => new Error(ex.Message));
        }





    }
}
