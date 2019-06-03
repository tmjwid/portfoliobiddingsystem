using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BiddingSystem.Common;
using BiddingSystem.Models.Account;
using BiddingSystem.Models.Company;
using BiddingSystem.Services.Contracts;

namespace BiddingSystem.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService userService;
        private readonly IUploadService uploadService;
        private readonly ICookieHelper cookieHelper;
        public RegistrationController(IUserService userService, ICookieHelper cookieHelper, IUploadService uploadService)
        {
            this.userService = userService;
            this.cookieHelper = cookieHelper;
            this.uploadService = uploadService;
        }

        [ImportModelState]
        public IActionResult Step1()
        {
            RegistrationModel model = new RegistrationModel();
            model.Company = new CompanyModel();
            model.Company.CompanyFunctions = new List<CompanyFunctionModel>();
            model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 1, Name = "Supplier" });
            model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 2, Name = "Buyer" });
            model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 3, Name = "Subcontractor" });

            model.Company.CompanyTypes = new List<CompanyTypeModel>();
            model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "LTD" });
            model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "PLC" });
            model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "Sole Trader" });

            if (TempData.Count > 0)
            {
                model = GetCurrentForm();
                model.LogoUpload = null;
                model.Company = new CompanyModel();
                model.Company.CompanyFunctions = new List<CompanyFunctionModel>();
                model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 1, Name = "Supplier" });
                model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 2, Name = "Buyer" });
                model.Company.CompanyFunctions.Add(new CompanyFunctionModel() { ID = 3, Name = "Subcontractor" });
                model.Company.CompanyTypes = new List<CompanyTypeModel>();
                model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "LTD" });
                model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "PLC" });
                model.Company.CompanyTypes.Add(new CompanyTypeModel() { ID = 1, Name = "Sole Trader" });
                return View(model);
            }
            else
            {
                SetCurrentForm(model);
            }

            return View(model);
        }

        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> Step1(RegistrationModel currentForm)
        {
            if (!ModelState.IsValid)
            {
                SetCurrentForm(currentForm);
                return RedirectToAction("Step1");
            }

            bool exist = userService.DoesUserExist(currentForm.User.EmailAddress);

            if (exist)
            {
                ModelState.AddModelError("User.EmailAddress", "Email address cannot be used, please use a different email address");
                return RedirectToAction("Step1");
            }

            if (currentForm.LogoUpload != null)
            {
                (string location, bool success) upload = await uploadService.ProcessUpload("company-logos", currentForm.LogoUpload);
                if (upload.success)
                {
                    currentForm.Company.LogoUrl = upload.location;
                }
            }

            var form = GetCurrentForm();
            form.User = currentForm.User;
            form.Company = currentForm.Company;
            SetCurrentForm(form);
            return RedirectToAction("Step2", "Registration");
        }

        [ImportModelState]
        public IActionResult Step2()
        {
            if (TempData.Count > 0)
            {
                return View(GetCurrentForm());
            }
            return View();
        }

        [HttpPost]
        [ExportModelState]
        public IActionResult Step2(RegistrationModel currentForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Step2");
            }

            var form = GetCurrentForm();
            form.Contact = currentForm.Contact;
            SetCurrentForm(form);
            return RedirectToAction("Step3", "Registration");
        }

        [ImportModelState]
        public IActionResult Step3()
        {
            if (TempData.Count > 0)
            {
                return View(GetCurrentForm());
            }
            return View();
        }

        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> Step3(RegistrationModel currentForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Step3");
            }

            var form = GetCurrentForm();
            form.MainAddress = currentForm.MainAddress;
            DatabaseCode registerResult = userService.Register(form);
            if (registerResult == DatabaseCode.Error || registerResult == DatabaseCode.Exists)
            {
                SetCurrentForm(form);
                ModelState.AddModelError("RegistrationError", "We are sorry, but we could register you at this time.");
                return RedirectToAction("Step3");
            }

            List<Claim> claims = new List<Claim>() { new Claim("user", form.User.EmailAddress) };
            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "LoginCookie", "user", "role")));
            TempData.Clear();
            return RedirectToAction("Dashboard", "Account");
        }

        [ImportModelState]
        public IActionResult Confirmation()
        {
            if (TempData.Count > 0)
            {
                return View(GetCurrentForm());
            }
            return View();
        }

        public async Task<IActionResult> CompleteConfirmation()
        {
            var form = GetCurrentForm();

            DatabaseCode registerResult = userService.Register(form);
            if (registerResult == DatabaseCode.Error || registerResult == DatabaseCode.Exists)
            {
                SetCurrentForm(form);
                return RedirectToAction("Confirmation", "Registration");
            }

            List<Claim> claims = new List<Claim>() { new Claim("user", form.User.EmailAddress) };
            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "LoginCookie", "user", "role")));
            TempData.Clear();
            return RedirectToAction("Dashboard", "Account");
        }

        private RegistrationModel GetCurrentForm()
        {
            return TempData.Get<RegistrationModel>("currentform");
        }

        private void SetCurrentForm(RegistrationModel currentForm)
        {
            TempData.Set("currentform", currentForm);
        }
    }
}