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
	public class AlarmniSistemController : Controller
	{
		[HttpGet]
		[Route("Obj/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Getobj(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveALarmneSistemeObjekat(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("Get/{serijskibr}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Get(string serijskibr)
		{
			try
			{
				return new JsonResult(DataProvider.VratiAlarmniSistem(serijskibr));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("List")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult List()
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveAlarmneSisteme());
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpDelete]
		[Route("Delete/{serijskibr}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Delete(string serijskibr)
		{
			try
			{
				DataProvider.ObrisiAlarmniSistem(serijskibr);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("DodajT/{objekatID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajT([FromBody] ToplotniAlarmniSistemView alarm, int objekatID)
		{
			try
			{
				var objekat = DataProvider.VratiObjekat(objekatID);
				alarm.Objekat = objekat;
				DataProvider.DodajToplotniAlarmniSistem(alarm);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost]
		[Route("DodajU/{objekatID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajU([FromBody] UltrazvucniAlarmniSistemView alarm, int objekatID)
		{
			try
			{
				var objekat = DataProvider.VratiObjekat(objekatID);
				alarm.Objekat = objekat;
				DataProvider.DodajUltrazvucniAlarmniSistem(alarm);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost]
		[Route("DodajD/{objekatID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Dodaj([FromBody] DetekcijaPokretaAlarmniSistemView alarm, int objekatID)
		{
			try
			{
				var objekat = DataProvider.VratiObjekat(objekatID);
				alarm.Objekat = objekat;
				DataProvider.DodajDetekcijaAlarmniSistem(alarm);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut]
		[Route("IzmeniT")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult IzmeniT([FromBody] ToplotniAlarmniSistemView p)
		{
			try
			{
				DataProvider.IzmeniToplotniAlarmniSistem(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
		[HttpPut]
		[Route("IzmeniU")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ChangeProdavnica([FromBody] UltrazvucniAlarmniSistemView p)
		{
			try
			{
				DataProvider.IzmeniUltrazvucniAlarmniSistem(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
		[HttpPut]
		[Route("IzmeniD")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ChangeProdavnica([FromBody] DetekcijaPokretaAlarmniSistemView p)
		{
			try
			{
				DataProvider.IzmeniDetekcijaAlarmniSistem(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}