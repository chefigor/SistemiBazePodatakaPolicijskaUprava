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
	public class PolicajacController : Controller
	{
		[HttpGet]
		[Route("Prikazi/{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Getobj(int id)
		{
			try
			{
				return new JsonResult(DataProvider.VratiPolicajca(id));
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
				return new JsonResult(DataProvider.VratiPolicajca(id));
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
				return new JsonResult(DataProvider.Vratisvepolicajce());
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
				DataProvider.ObrisiPolicajca(id);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("DodajVanrednog/{stanicaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajPozornika([FromBody] VanredniPolicajacView vanredni, int stanicaID)
		{
			try
			{
				var stanica = DataProvider.VratiPolicijskuStanicu(stanicaID);
				vanredni.PolicijskaStanica = stanica;
				DataProvider.DodajVanrednogPolicajaca(vanredni);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("DodajSkolskog/{stanicaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajSkolskog([FromBody] SkolskiPolicajacView spol, int stanicaID)
		{
			try
			{
				var stanica = DataProvider.VratiPolicijskuStanicu(stanicaID);
				spol.PolicijskaStanica = stanica;
				DataProvider.DodajSkolskogPolicajca(spol);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("DodajPozornika/{stanicaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult DodajPozornika([FromBody] PozornikPolicajacView pozornik, int stanicaID)
		{
			try
			{
				var stanica = DataProvider.VratiPolicijskuStanicu(stanicaID);
				pozornik.PolicijskaStanica = stanica;
				DataProvider.DodajPolicajcaPozornika(pozornik);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("DodajObicnog/{stanicaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Dodaj([FromBody] ObicanPolicajacView obican, int stanicaID)
		{
			try
			{
				var stanica = DataProvider.VratiPolicijskuStanicu(stanicaID);
				obican.PolicijskaStanica = stanica;
				DataProvider.DodajObicnogPolicajca(obican);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut]
		[Route("IzmeniO")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult izmeniO([FromBody] ObicanPolicajacView p)
		{
			try
			{
				DataProvider.IzmeniObicnogPolicajca(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut]
		[Route("IzmeniS")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult IzmeniS([FromBody] SkolskiPolicajacView p)
		{
			try
			{
				DataProvider.IzmeniSkolskogPolicajca(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut]
		[Route("IzmeniP")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult IzmeniP([FromBody] PozornikPolicajacView p)
		{
			try
			{
				DataProvider.IzmeniPozornikPolicajca(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}

		[HttpPut]
		[Route("IzmeniV")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult IzmeniV([FromBody] VanredniPolicajacView p)
		{
			try
			{
				DataProvider.IzmeniVanrednogPolicajca(p);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.ToString());
			}
		}
	}
}