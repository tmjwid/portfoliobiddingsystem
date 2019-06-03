
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BiddingSystem.Models.Company;
using BiddingSystem.Models.Bid;
using BiddingSystem.Models.Product;

namespace BiddingSystem.Models.Account
{
    public class CompanyModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a correct company number (9 digits long)")]
        public int CompanyNumber { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public int CompanyAddressID { get; set; }

        public int? VatNumber { get; set; }
        public string LogoUrl { get; set; }

        //fk
        public int CompanyFunctionID { get; set; }
        public int CompanyTypeID { get; set; }
        //Objects
        public AddressModel CompanyAddress { get; set; }
        public ContactModel PrimaryContact { get; set; }
        public CompanyFunctionModel CompanyFunction { get; set; }
        public CompanyTypeModel CompanyType { get; set; }
        public List<CompanyTypeModel> CompanyTypes { get; set; }
        public List<CompanyFunctionModel> CompanyFunctions { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}