using System;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface IUserMapper
    {
        User ToEntity(UserModel userModel);
        UserModel ToModel(User user);
    }
}
