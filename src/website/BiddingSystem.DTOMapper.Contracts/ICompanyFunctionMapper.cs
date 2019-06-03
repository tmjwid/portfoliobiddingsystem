using BiddingSystem.Entities;
using BiddingSystem.Models.Company;

namespace BiddingSystem.DTOMapper.Contracts
{
    public interface ICompanyFunctionMapper
    {
        CompanyFunctionModel ToModel(CompanyFunction company);
    }
}