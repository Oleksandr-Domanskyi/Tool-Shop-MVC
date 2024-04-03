using FluentResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.DataBase;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Repositories;

namespace ToolShopInfrastructure.Services
{
    public class EntityService<EntityType>: IEntityService<EntityType> where EntityType : Entity<int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ToolShopDbContext dbContext;

        public EntityService(IUnitOfWork unitOfWork, ToolShopDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            this.dbContext = dbContext;
        }

        public async Task<Result<EntityType>> AddEntityAsync(EntityType entity)
        {
            try
            {

                await _unitOfWork.Repository<EntityType>().AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail<EntityType>(ex.Message);
            }

            /*return await Result.Try(async Task<EntityType> () =>
                await _unitOfWork.Repository<EntityType>().AddAsync(entity),
                ex => new Error(ex.Message));*/
        }
        public async Task<Result<EntityType>> GetByIdAsync(int id)
        {
            return await Result.Try(async Task<EntityType> () =>
                await _unitOfWork.Repository<EntityType>().GetByIdAsync(id),
                ex =>new Error(ex.Message));
        }

        public async Task<Result<List<EntityType>>> GetListAsync()
        {
            return await Result.Try(async Task<List<EntityType>> () =>
                await _unitOfWork.Repository<EntityType>().ListAsync(),
                ex => new Error(ex.Message));
        }





    }
}
