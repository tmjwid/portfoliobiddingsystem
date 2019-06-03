using System;
using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Models.Account;
using BiddingSystem.Repository.Contracts;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyMapper companyMapper;

        public CompanyService(ICompanyMapper companyMapper, ICompanyRepository companyRepository)
        {
            this.companyMapper = companyMapper;
            this.companyRepository = companyRepository;
        }

        public int GetCompanyIDByUserUsername(string username)
        {
            return companyRepository.GetCompanyIDByUserUsername(username);
        }

        public (int companyID, DatabaseCode dbCOde) Insert(CompanyModel company)
        {
            return companyRepository.Insert(companyMapper.ToEntity(company));
        }
    }
}