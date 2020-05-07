﻿using CmApp.Contracts;
using CmApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CmApp.Controllers
{
    [Authorize(Roles = "user, admin", AuthenticationSchemes = "user, admin")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly ICarRepository carRepository = new CarRepository();
        private readonly IExternalAPIService externalAPI = new ExternalAPIService();

        [HttpGet]
        [Route("/api/makes")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetAllMakes()
        {
            try
            {
                var makes = await carRepository.GetAllMakes();
                List<string> namesOnly = makes.Select(x => x.Name).ToList();
                namesOnly.Sort();
                return Ok(namesOnly);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/makes/{makeName}/models")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetAllMakeModels(string makeName)
        {
            try
            {
                var makes = await externalAPI.GetAllMakeModels(makeName);
                makes.Sort();
                return Ok(makes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Custom
        [Route("api/user-car-names")]
        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IActionResult> GetCarNames()
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var cars = await carRepository.GetAllUserCars(userId);
                var result = new List<object>();
                foreach (var car in cars)
                    result.Add(new { value = car.Id, text = car.Make + " " + car.Model });

                if (result.Count != 0)
                    return Ok(result);
                else
                    throw new Exception("No cars yet");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/get-image")]
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> GetImage([FromBody] object image)
        {
            try
            {
                FileRepository fileRepo = new FileRepository();
                var fileInfo = fileRepo.GetFileId(image);

                var fileId = fileInfo.Item1;
                var fileType = fileInfo.Item2;

                var fileUrl = await fileRepo.GetFileUrl(fileId);
                return Ok(fileUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/get-image2")]
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> GetImage2([FromBody] object image)
        {
            try
            {
                FileRepository fileRepo = new FileRepository();
                var fileInfo = fileRepo.GetFileId(image);

                var fileId = fileInfo.Item1;
                var fileType = fileInfo.Item2;

                var stream = await fileRepo.GetFile(fileId);

                var mem = new MemoryStream();
                stream.CopyTo(mem);

                var bytes = fileRepo.StreamToByteArray(mem);
                string base64 = fileRepo.ByteArrayToBase64String(bytes);

                base64 = "data:" + fileType + ";base64," + base64;

                return Ok(base64);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/countries")]
        [Authorize(Roles = "user, admin")]
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                ExternalAPIService repo = new ExternalAPIService();
                var countries = await repo.GetAllCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
