using IMS.infrastructure.IRepository;
using IMS.Models.Entity;
using IMS.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;

namespace IMS.web.Controllers
{
    [Authorize]

    public class StoreInfoController : Controller

    {
        private readonly ICrudService<StoreInfo> _storeInfoCrudService;

        private readonly UserManager<ApplicationUser> _userManager;
        public StoreInfoController(ICrudService<StoreInfo> storeCrudSerivice,
            UserManager<ApplicationUser> userManager)
        {
            _storeInfoCrudService = storeCrudSerivice;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var storeInfoList = await _storeInfoCrudService.GetAllAsync();
            return View(storeInfoList);
        }
        //[HttpGet]
        //public async Task<IActionResult> Delete(string userId)
        //{
        //    //Get the user
        //    var userIdToDelete = await _userManager.FindByIdAsync(userId);

        //    if (userIdToDelete != null)
        //    {
        //        await _userManager.DeleteAsync(userIdToDelete);

        //        TempData["Error"] = "Data deleted successfully!🥲";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}



        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            StoreInfo storeInfo = new StoreInfo();
            if (id > 0)
            {
                storeInfo = await _storeInfoCrudService.GetAsync(id);
            }

            return View(storeInfo);
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(StoreInfo storeInfo)
        {

            var userId = _userManager.GetUserId(HttpContext.User);

            if (storeInfo.Id == 0)
            {
                storeInfo.CreatedDate = DateTime.Now;
                storeInfo.CreatedBy = userId;

                await _storeInfoCrudService.InsertAsync(storeInfo);
                TempData["Success"] = "Data Added Successfully";

            }

            else
            {
                var OrgStoreInfo = await _storeInfoCrudService.GetAsync(storeInfo.Id);
                OrgStoreInfo.StoreName = storeInfo.StoreName;
                OrgStoreInfo.Address = storeInfo.Address;
                OrgStoreInfo.phoneNumber = storeInfo.phoneNumber;
                OrgStoreInfo.PanNo = storeInfo.PanNo;
                OrgStoreInfo.RegistratinNo = storeInfo.RegistratinNo;
                OrgStoreInfo.IsActive = storeInfo.IsActive;
                OrgStoreInfo.MOdifiedBy = userId;
                OrgStoreInfo.ModifiedDate = storeInfo.ModifiedDate;

                await _storeInfoCrudService.UpdateAsync(OrgStoreInfo);
                TempData["success"] = "Data Updated Successfully";

            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var storeInfo = await _storeInfoCrudService.GetAsync(id);
            _storeInfoCrudService.Delete(storeInfo);

            TempData["Error"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}