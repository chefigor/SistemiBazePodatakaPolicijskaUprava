using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpravaLibrary;
using UpravaLibrary.DTOs;
using UpravaLibrary.Entiteti;

namespace UpravaWebApiService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UlicaController : Controller
	{
		[HttpGet]
		[Route("Get/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Get(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveUlice(id));
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
				DataProvider.ObrisiUlicu(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("Dodaj/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajUlicu([FromBody] UlicaView ul, int id)
		{
			try
			{
				var policajac = DataProvider.VratiPozornika(id);
				if (policajac == null)
				{
					return BadRequest("Policajac null");
				}
				ul.Policajac =policajac;
				DataProvider.DodajUlicu(ul);
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
		public IActionResult IzmeniUlicu([FromBody] UlicaView c)
		{
			try
			{
				DataProvider.IzmeniUlicu(c);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}