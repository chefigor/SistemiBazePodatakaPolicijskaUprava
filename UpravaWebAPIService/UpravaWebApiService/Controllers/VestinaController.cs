using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpravaLibrary;
using UpravaLibrary.DTOs;

namespace UpravaWebApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VestinaController : Controller
    {
        //
        [HttpGet]
        [Route("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiVestine(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                DataProvider.ObrisiVestinu(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //
        [HttpPost]
        [Route("Dodaj/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajVestinu([FromBody] VestinaView vestina, int id)
        {
            try
            {
                var policajac = DataProvider.VratiVanrednogPolicajca(id);
                vestina.Policajac = policajac;
                DataProvider.DodajVestinu(vestina);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //
        [HttpPut]
        [Route("Izmeni")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IzmeniVestinu([FromBody] VestinaView v)
        {
            try
            {
                DataProvider.IzmeniVestinu(v);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
