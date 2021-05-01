using AutoMapper;
using OnlineShop.DAL.IRepositories;
using OnlineShop.DTOModels;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper _mapper;
        private readonly OnlineShopContext _context;

        public TransactionRepository(IMapper mapper, OnlineShopContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task<int> Post(TransactionDTO input)
        {
            var model = _mapper.Map<Transaction>(input);
            await _context.AddAsync(model);
            return await _context.SaveChangesAsync();
        }
    }
}
