using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BiddingSystem.Models.Company;

namespace BiddingSystem.Models.Account
{
    public class RegistrationModel : MessageViewModel
    {
        //session data
        public Guid RegistrationToken { get; set; }

        // form data 
        public UserModel User { get; set; }
        public ContactModel Contact { get; set; }
        public AddressModel MainAddress { get; set; }
        public CompanyModel Company { get; set; }
        public bool UseSameAddressForCompany { get; set; }
        public bool UseSameContactForCompany { get; set; }
        [JsonIgnore]
        public IFormFile LogoUpload { get; set; }

        // view data 
        public List<CompanyFunctionModel> CompanyFunctions { get; set; }
        public List<CompanyTypeModel> CompanyTypes { get; set; }
        public int SubcontractorTypesSearchID { get; set; }


    }
}