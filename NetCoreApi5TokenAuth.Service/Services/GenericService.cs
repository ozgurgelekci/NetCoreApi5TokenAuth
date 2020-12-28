using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreApi5TokenAuth.Core.Entities.Abstract;
using NetCoreApi5TokenAuth.Core.Repositories.Abstract;
using NetCoreApi5TokenAuth.Core.Services.Abstract;
using NetCoreApi5TokenAuth.Core.UnitOfWork.Abstract;
using NetCoreApi5TokenAuth.Service.Mappings;
using SharedLibrary.DTOs;

namespace NetCoreApi5TokenAuth.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class, IEntity, new() where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<ResponseDto<TDto>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return ResponseDto<TDto>.Fail("Id not found", 404, true);
            }

            return ResponseDto<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(entity), 200);
        }

        public async Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return ResponseDto<IEnumerable<TDto>>.Success(entities, 200);
        }

        public async Task<ResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list =  _genericRepository.Where(predicate);
            return ResponseDto<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()),200);
        }

        public async Task<ResponseDto<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);

            return ResponseDto<TDto>.Success(newDto, 200);
        }

        public async Task<ResponseDto<NoDataDto>> Remove(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return ResponseDto<NoDataDto>.Fail("Id not found", 404, true);
            }

            _genericRepository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return ResponseDto<NoDataDto>.Success(204);
        }

        public async Task<ResponseDto<NoDataDto>> Update(TDto entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return ResponseDto<NoDataDto>.Fail("Id not found", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);

            _genericRepository.Update(updateEntity);
            await _unitOfWork.CommitAsync();

            return ResponseDto<NoDataDto>.Success(204);
        }
    }
}
