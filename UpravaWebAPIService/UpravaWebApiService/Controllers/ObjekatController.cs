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
	public class ObjekatController : Controller
	{
		[HttpGet]
		[Route("List")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult List()
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveObjekte());
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("List/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListPolicijskaStanica(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSveObjektePolicijskaStanica(id));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("Get/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Get(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiObjekat(id));
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
				DataProvider.ObrisiObjekat(id);
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
		public IActionResult DodajObjekat([FromBody] ObjekatView objekat, int id)
		{
			try
			{
				var policijskastanica = DataProvider.VratiPolicijskuStanicu(id);
				objekat.PolicijskaStanica = policijskastanica;
				DataProvider.DodajObjekat(objekat);
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
		public IActionResult IzmeniObjekat([FromBody] ObjekatView objekat)
		{
			try
			{
				DataProvider.IzmeniObjekat(objekat);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}