using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Company;

namespace BiddingSystem.DTOMapper
{
    public class CompanyFunctionMapper : ICompanyFunctionMapper
    {
        public CompanyFunctionModel ToModel(CompanyFunction companyFunction)
        {
            return new CompanyFunctionModel(){
                ID = companyFunction.id,
                Name = companyFunction.name
            };
        }
    }
}