using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface ITransactionRepository
    {
        public Task<int> Post(TransactionDTO input);
    }
}
