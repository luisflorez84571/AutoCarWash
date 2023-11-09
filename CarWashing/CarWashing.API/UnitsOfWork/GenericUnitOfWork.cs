﻿using CarWashing.API.Repositories;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Responses;

namespace CarWashing.API.UnitsOfWork
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Response<T>> AddAsync(T model) => await _repository.AddAsync(model);

        public virtual async Task<Response<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual async Task<Response<IEnumerable<T>>> GetAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);

        public virtual async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _repository.GetTotalPagesAsync(pagination);

        public virtual async Task<Response<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public virtual async Task<Response<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);
    }
}