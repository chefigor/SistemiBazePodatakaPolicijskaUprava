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
    public class ZaduzenController : Controller
    {
        //
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult List(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZaduzene());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //
        [HttpGet]
        [Route("GetAlarm/{serijskibr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZaduzenAlarm(string serijskibr)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZaduzeneAlarm(serijskibr));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //
        [HttpGet]
        [Route("GetTehnicar/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZaduzenTehnicar(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZaduzeneTehnicar(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //
        [HttpGet]
        [Route("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZaduzen(int id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiZaduzenog(id));
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
                DataProvider.ObrisiZaduzenog(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //
        [HttpPost]
        [Route("Dodaj/{alarmid}/{tehnicarid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DodajZaduzenog([FromBody] ZaduzenView zaduzen, string alarmid, int tehnicarid)
        {

         
            try
            {
                var alarm = DataProvider.VratiAlarmniSistem(alarmid);
                zaduzen.Alarm = alarm;
                var tehnicar = DataProvider.VratiTehnickoLice(tehnicarid);
               zaduzen.Tehnicar = tehnicar;
                DataProvider.DodajZaduzenog(zaduzen);
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
        public IActionResult IzmeniZaduzenog([FromBody] ZaduzenView z)
        {
            try
            {
                DataProvider.IzmeniZaduzenog(z);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
