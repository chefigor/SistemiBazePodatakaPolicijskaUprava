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
	public class PatrolaController : Controller
	{
		[HttpGet]
		[Route("Get/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetPatrolaPolicajac(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiPatrolu(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Delete(int id)
		{
			try
			{
				DataProvider.ObrisiPatrolu(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("Dodaj/{vodjaid}/{partnerid}/{voziloid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajPatrolu([FromBody] PatrolaView patrola, int vodjaid, int partnerid, int voziloid)
		{
			try
			{
				var vodja = DataProvider.VratiObicnogPolicajca(vodjaid);
				var partner = DataProvider.VratiObicnogPolicajca(partnerid);
				var vozilo = DataProvider.VratiVozilo(voziloid);

				patrola.Vodja = vodja;
				patrola.Partner = partner;
				patrola.Vozilo = vozilo;
				DataProvider.DodajPatrolu(patrola);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}