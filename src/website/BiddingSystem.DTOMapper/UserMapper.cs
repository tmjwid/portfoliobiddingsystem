using System;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper
{
    public class UserMapper : IUserMapper
    {
        private readonly ICompanyMapper companyMapper;
        private readonly IProductMapper productMapper;
        public UserMapper(ICompanyMapper companyMapper, IProductMapper productMapper)
        {
            this.companyMapper = companyMapper;
            this.productMapper = productMapper;
        }
        public User ToEntity(UserModel userModel)
        {
            User user = new User();
            user.id = userModel.ID;
            user.password = userModel.Password;
            user.username = userModel.EmailAddress;
            user.companyid = userModel.CompanyID;
            user.company = userModel.Company != null ? companyMapper.ToEntity(userModel.Company) : null;
            return user;
        }

        public UserModel ToModel(User user)
        {
            UserModel userModel = new UserModel();
            userModel.ID = user.id;
            userModel.EmailAddress = user.username;
            userModel.CompanyID = user.companyid;
            userModel.Company = user.company != null ? companyMapper.ToModel(user.company) : null;
            return userModel;
        }
    }
}
