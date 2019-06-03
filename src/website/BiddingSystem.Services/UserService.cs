using System;
using Microsoft.Extensions.Logging;
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models;
using BiddingSystem.Models.Account;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserMapper userMapper;
        private readonly IContactService contactService;
        private readonly IAddressService addressService;
        private readonly ICompanyService companyService;
        private readonly ILogger<UserService> logger;
        public UserService(IUserRepository userRepository, IUserMapper userMapper, ILogger<UserService> logger, IContactService contactService,
        IAddressService addressService, ICompanyService companyService)
        {
            this.userRepository = userRepository;
            this.userMapper = userMapper;
            this.contactService = contactService;
            this.addressService = addressService;
            this.companyService = companyService;
            this.logger = logger;
        }

        public bool DoesUserExist(string userName)
        {
            return userRepository.Exist(userName);
        }

        public UserModel GetFullUser(string userName)
        {
            UserModel user = userMapper.ToModel(userRepository.GetFullUser(userName));
            return user;
        }

        public UserModel GetUser(string userName)
        {
            return userMapper.ToModel(userRepository.GetUser(userName));
        }

        public Guid GetUserID(string userName)
        {
            return userRepository.GetUserID(userName);
        }

        public (Guid userID, int companyID) GetUserAndCompanyID(string userName)
        {
            return userRepository.GetUserAndCompanyID(userName);
        }

        public bool Login(UserModel loginModel)
        {
            return userRepository.Login(userMapper.ToEntity(loginModel));
        }

        public DatabaseCode Register(RegistrationModel registerModel)
        {
            registerModel.User.ID = Guid.NewGuid();
            (int CompanyID, DatabaseCode CompanyStatus) companyInserted = companyService.Insert(registerModel.Company);
            if (companyInserted.CompanyStatus == DatabaseCode.Error)
            {
                return companyInserted.CompanyStatus;
            }
            registerModel.User.CompanyID = companyInserted.CompanyID;
            DatabaseCode userInserted = userRepository.Insert(userMapper.ToEntity(registerModel.User));

            if (userInserted == DatabaseCode.Inserted)
            {
                registerModel.Contact.UserID = registerModel.User.ID;
                registerModel.Contact.CompanyID = companyInserted.CompanyID;
                contactService.CreateContact(registerModel.Contact);
                registerModel.MainAddress.UserID = registerModel.User.ID;
                registerModel.MainAddress.CompanyID = companyInserted.CompanyID;
                return addressService.CreateAddress(registerModel.MainAddress).dbCode;
            }
            return userInserted;
        }
    }
}
