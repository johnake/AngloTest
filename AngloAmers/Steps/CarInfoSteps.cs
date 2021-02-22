using System;
using TechTalk.SpecFlow;
using AngloAmers.Actions;
using NUnit.Framework;
using System.Collections.Generic;
using AngloAmers.Model;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using AngloAmers.Service;

namespace AngloAmers.Steps
{
    [Binding]
    public class CarInfoSteps
    {
        GetRequests getRequests;
        private Dictionary<int, String> MyObjects;

        [Given(@"The system knows about all cars")]
        public void GivenTheSystemKnowsAboutAllCars()
        {
            getRequests = new GetRequests();
        }

        [When(@"the client requests a car information by type (.*)")]
        public void WhenTheClientRequestsACarInformationByType(string type)
        {
            getRequests.GetCarByType(type).Wait();
        }

        [Then(@"the client sees response code (.*) for (.*)")]
        public void ThenTheClientSeesResponseCodeForSearch(string code, string type)
        {
            getRequests.GetCarByTypeResponseCode(type).Wait();
            Assert.AreEqual(code, getRequests._responseCode.ToString());
        }


        [Then(@"the response contains the make (.*) of the car")]
        public void ThenTheResponseContainsTheMakeToyotaOfTheCar(string make)
        {
            Assert.AreEqual(make, getRequests.car[0].Make);
        }

        [Then(@"the response has the following makes")]
        public void ThenTheResponseHasTheFollowingMakes(Table table)
        {
            this.MyObjects = new Dictionary<int, String>();
            var car = table.CreateSet<Car>();
            foreach (Car item in car)
            {
                this.MyObjects.Add(item.ID, item.Make);
            }
            List<string> actualCars = new List<string>();
            for (int i = 0; i < getRequests.car.Count; i++)
            {
                actualCars.Add(getRequests.car[i].Make);
            }

            List<String> expectedCars = MyObjects.Values.ToList();

            CollectionAssert.AreEqual(expectedCars, actualCars);
        }

        
    }
}

