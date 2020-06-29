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
	public class SertifikatController : Controller
	{
		[HttpGet]
		[Route("Get/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Get(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiSertifikate(id));
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
				DataProvider.ObrisiSertifikat(id);
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
		public IActionResult DodajSertifikat([FromBody] SertifikatView sertifikat, int id)
		{
			try
			{
				var policajac = DataProvider.VratiPolicajca(id);
				//sertifikat.Policajac = policajac; ovo nece
				DataProvider.DodajSertifikat(sertifikat);
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
		public IActionResult IzmeniSertifikat([FromBody] SertifikatView c)
		{
			try
			{
				DataProvider.IzmeniSertifikat(c);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}