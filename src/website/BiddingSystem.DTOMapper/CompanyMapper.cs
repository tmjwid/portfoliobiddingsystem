using BiddingSystem.Common;
using BiddingSystem.DTOMapper.Contracts;
using BiddingSystem.Entities;
using BiddingSystem.Models.Account;

namespace BiddingSystem.DTOMapper
{
    public class CompanyMapper : ICompanyMapper
    {
        private readonly IProductMapper productMapper;
        private readonly ICompanyFunctionMapper companyFunctionMapper;

        public CompanyMapper(IProductMapper productMapper, ICompanyFunctionMapper companyFunctionMapper)
        {
            this.productMapper = productMapper;
            this.companyFunctionMapper = companyFunctionMapper;
        }

        public Company ToEntity(CompanyModel companyModel)
        {
            Company company = new Company();
            company.companyfunctionid = companyModel.CompanyFunctionID;
            company.companyname = companyModel.CompanyName;
            company.companynumber = companyModel.CompanyNumber;
            company.companytypeid = companyModel.CompanyTypeID;
            company.id = companyModel.ID;

            company.logourl = companyModel.LogoUrl;
            return company;
        }

        public CompanyModel ToModel(Company company)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.CompanyFunctionID = company.companyfunctionid;
            companyModel.CompanyName = company.companyname;
            companyModel.CompanyNumber = company.companynumber;
            companyModel.CompanyTypeID = company.companytypeid;
            companyModel.ID = company.id;
            // companyModel.SubcontractorTypes = company.subcontactors.SubContractorTypeIDs;
            companyModel.Products = company.products != null ? productMapper.ToModelList(company.products) : null;
            companyModel.CompanyFunction = company.companyfunction != null ? companyFunctionMapper.ToModel(company.companyfunction) : null;
            return companyModel;
        }
    }
}