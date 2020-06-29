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
	public class IntervencijaController : Controller
	{
		[HttpGet]
		[Route("List")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult List(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveIntervencije());
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("GetPatrola/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetIntervencijaPatrola(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveIntervencijePatrola(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("GetObjekat/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetIntervencijaObjekat(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratisveIntervencijeObjekat(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("Get/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GetIntervencija(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiIntervenciju(id));
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
				DataProvider.ObrisiIntervenciju(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("Dodaj/{patrolaid}/{objekatid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajIntervenciju([FromBody] IntervencijaView intervencija, int patrolaid, int objekatid)
		{
			try
			{
				var patrola = DataProvider.VratiPatrolu(patrolaid);
				intervencija.Patrola = patrola;
				var objekat = DataProvider.VratiObjekat(objekatid);
				intervencija.Objekat = objekat;
				DataProvider.DodajIntervenciju(intervencija);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut]
		[Route("Izmeni")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult IzmeniIntervenciju([FromBody] IntervencijaView i)
		{
			try
			{
				DataProvider.IzmeniIntervenciju(i);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}