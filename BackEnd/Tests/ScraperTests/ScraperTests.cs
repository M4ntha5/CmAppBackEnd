﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using CmApp.Services;
using System.Threading.Tasks;
using CmApp.Repositories;
using CmApp.Domains;
using CmApp.Entities;
using CmApp.Utils;

namespace ScraperTests
{
    public class ScraperTests
    {
        string Vin = string.Empty;
        ScraperService scraperService;

        [SetUp]
        public void Setup()
        {
            Settings.ApiKey = Environment.GetEnvironmentVariable("ApiKey");
            Settings.CaptchaApiKey = Environment.GetEnvironmentVariable("CaptchaApiKey");
            Vin = "wba3b1g58ens79736";
            scraperService = new ScraperService();
        }

        [Test]
        public void TestGetVehicleInfo()
        {
            var equipment = scraperService.GetVehicleInfo(Vin, "BMW");

            Assert.AreNotEqual(null, equipment);
        }

        [Test]
        public void TestGetVehicleEquipment()
        {
            var equipment = scraperService.GetVehicleEquipment(Vin, "BMW");

            Assert.AreNotEqual(null, equipment);
        }

        [Test]
        public async Task TestTrackingScraper()
        {
            var repo = new CarRepository();

            var vin = "WBA7E2C37HG740629";
            vin = "wba3n9c56ek245582";
            //vin = "WBS1J5C56JVD36905";
            //vin = "WBA3A9G51FNT09002";

            var trackingId = "asd";

            var cars = await repo.GetAllCars();
            await scraperService.TrackingScraper(cars[0], trackingId);

        }

        [Test]
        public async Task TestMBScraper()
        {
            var vin = "WDDLJ7EB1CA031646";
            var make = "Mercedes-benz";

            var carService = new CarService()
            {
                CarRepository = new CarRepository(),
                FileRepository = new FileRepository(),
                SummaryRepository = new SummaryRepository(),
                WebScraper = new ScraperService()
            };

            var car = new CarEntity()
            {
                Vin = vin,
                Make = make
            };

            var result = await carService.InsertCar(car);

            Assert.AreNotEqual(null, result);
        }
    }
}
