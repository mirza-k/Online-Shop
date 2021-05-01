﻿using OnlineShop.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.IRepositories
{
    public interface IClothesSizeRepository
    {
        public Task<IEnumerable<ClothesSizeDTO>> Get();
        public Task<ClothesSizeDTO> GetById(int id);
    }
}
