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
    public class TehnickoLiceController : Controller
    {
        //
        [HttpGet]
        [Route("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTehnickoLice(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiTehnickoLice(id));
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
                DataProvider.ObrisiTehnickoLice(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //
        [HttpPost]
        [Route("Dodaj/{vodjaid}/{partnerid}/{voziloid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajTehnickoLice([FromBody] TehnickoLiceView tehnicko, int id)
        {
        
            try
            {
              
                DataProvider.DodajTehnickoLice(tehnicko);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}