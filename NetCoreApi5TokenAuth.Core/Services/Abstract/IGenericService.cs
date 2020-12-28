﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCoreApi5TokenAuth.Core.Entities.Abstract;
using SharedLibrary.DTOs;

namespace NetCoreApi5TokenAuth.Core.Services.Abstract
{
    public interface IGenericService<TEntity, TDto> where TEntity : class, IEntity, new() where TDto : class
    {
        Task<ResponseDto<TDto>> GetByIdAsync(int id);

        Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync();

        Task<ResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);

        Task<ResponseDto<TDto>> AddAsync(TEntity entity);

        Task<ResponseDto<NoDataDto>> Remove(TEntity entity);

        Task<ResponseDto<NoDataDto>> Update(TEntity entity);
    }
}
