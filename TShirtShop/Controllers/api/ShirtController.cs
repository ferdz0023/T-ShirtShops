using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TShirtShop.BLL;
using TShirtShop.Core.Models;
using TShirtShop.Core.ViewModels;
using TShirtShop.Data;

namespace TShirtShop.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShirtController : ControllerBase
    {
        private readonly IShirtServices _shirtServices;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public ShirtController(IShirtServices shirtServices, ISizeRepository sizeRepository, IMapper mapper)
        {
            _shirtServices = shirtServices;
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ShirtViewModel[]>> GetShirts()
        {
            try
            {
                var results = await _shirtServices.GetShirts();

                if (!results.Any())
                    NotFound();
                return _mapper.Map<ShirtViewModel[]>(results);


            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShirtViewModel>>GetShirt(int id)
        {
            try
            {
                var results = await _shirtServices.GetShirtBy(id);
                if (results == null)
                    NotFound();
                return _mapper.Map<ShirtViewModel>(results);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var results = await _shirtServices.GetShirtBy(id);
                if (results == null)
                    NotFound();
                 _shirtServices.Remove(id);
                
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

    }
}
