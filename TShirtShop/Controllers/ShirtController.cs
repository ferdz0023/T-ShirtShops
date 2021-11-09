using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TShirtShop.BLL;
using TShirtShop.Core;

using TShirtShop.Core.Models;
using TShirtShop.Core.ViewModels;
using TShirtShop.Data;
using TShirtShop.Helper;

namespace TShirtShop.Controllers
{
    public class ShirtController : Controller
    {
        private readonly ISizeRepository _sizeRepository;

        private readonly IShirtServices _shirtServices;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;


        public ShirtController(IShirtServices shirtServices, ISizeRepository sizeRepository, IHtmlHelper htmlHelper, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _shirtServices = shirtServices;
            _sizeRepository = sizeRepository;
            _htmlHelper = htmlHelper;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        public async Task<IActionResult> ShirtSetting()
        {
            var shirts = await _shirtServices.GetShirts();
            return View(shirts);
        }
        public async Task<IActionResult> Index()
        {
            var shirts = await _shirtServices.GetShirts();
            return View(shirts);
        }
        [Authorize]
        public async Task<ActionResult> Add()
        {
            var shirtmodel = new ShirtViewModel();
            shirtmodel.Genders = _htmlHelper.GetEnumSelectList<GenderEnum>();
            var sizeResult = await _sizeRepository.GetAllSizes();
            shirtmodel.Sizes = sizeResult.Select(x => new SelectListItem { Value = x.SizeId.ToString(), Text = x.Name }).ToList();

            return View(shirtmodel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(ShirtViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Add", viewModel);
            string webRootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            var inputStream = HttpContext.Request.Body;

            var shirt = _mapper.Map<Shirt>(viewModel);
            //if (viewModel.Id != 0)
            //{
            //    shirt = await _shirtServices.GetShirtBy(viewModel.Id);
            //}


            if (files.Count > 0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);
                var imageHelper = new ImageHelper();

                //Delete the existing images

                if (shirt.ShirtId > 0)
                {
                    var imagePathOriginal = Path.Combine(webRootPath, shirt.ImageLocation.TrimStart('\\'));
                    var imagePathThumb = Path.Combine(webRootPath, shirt.ImageThumnNailLocation.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePathOriginal))
                    {
                        System.IO.File.Delete(imagePathOriginal);
                       
                    }
                    if (System.IO.File.Exists(imagePathThumb))
                    {
                        System.IO.File.Delete(imagePathThumb);
                    }

                }

                //Upload new images
                shirt.ImageLocation = imageHelper.GetImagePath(files, uploads);
                shirt.ImageThumnNailLocation = imageHelper.GetThumnailPath(shirt.ImageLocation, uploads, extension);
            }
            else
            {
                var shirtdb = await _shirtServices.GetShirtBy(shirt.ShirtId);
                shirt.ImageLocation = shirtdb.ImageLocation;
                shirt.ImageThumnNailLocation = shirtdb.ImageThumnNailLocation;


            }

            if (shirt.ShirtId > 0)
            {
                _shirtServices.Update(shirt);
            }
            else
                _shirtServices.Insert(shirt);



            return RedirectToAction("Index");
        }
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var shirt = await _shirtServices.GetShirtBy(id);
            var shiftViewModel = new ShirtViewModel();
            shiftViewModel = _mapper.Map<ShirtViewModel>(shirt);
            shiftViewModel.Genders = _htmlHelper.GetEnumSelectList<GenderEnum>();
            var sizeResult = await _sizeRepository.GetAllSizes();
            shiftViewModel.Sizes = sizeResult.Select(x => new SelectListItem { Value = x.SizeId.ToString(), Text = x.Name }).ToList();

            return View(shiftViewModel);
        }
        public async Task<ActionResult> Delete (int id)
        {
            var shirt = await _shirtServices.GetShirtBy(id);
            if(shirt != null)
            {
                shirt.IsActive = false;
                _shirtServices.Update(shirt);
            }
            return RedirectToAction("Index");
        }
    }
}
