using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface ICompanyMapper
    {
         
         Company ToEntity(CompanyModel companyModel);
         CompanyModel ToModel(Company company);
    }
}