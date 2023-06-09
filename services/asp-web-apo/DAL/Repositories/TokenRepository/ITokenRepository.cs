﻿using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories.TokenRepository
{
    public interface ITokenRepository : IRepository<Token>, IGetByTokenRepository<Token>, IGetByUserIdRepository<Token>
    {
    }
}
