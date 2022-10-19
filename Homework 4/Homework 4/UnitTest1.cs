using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceReference1;

namespace Homewrok4    
{
    [TestClass]
    public class Unittest1
    {
        private static CountryInfoServiceSoapTypeClient countryInfoServiceSoapType = null;

        [TestInitialize]
        public void TestInit()
        {
            countryInfoServiceSoapType = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void ValidationOfCountryListByAscending()
        {
            List<tCountryCodeAndName> countryNamesList = countryInfoServiceSoapType.ListOfCountryNamesByCode();

            var ascendingOrder = countryNamesList.OrderBy(a => a.sISOCode);

            Assert.IsTrue(countryNamesList.SequenceEqual(ascendingOrder), "Not Ascending");

        }


        [TestMethod]
        public void ValidationOfInvalidCountryCode()
        {
            string countryCode = "asdad";
            var countryName = countryInfoServiceSoapType.CountryName(countryCode);

            Assert.AreEqual("Country not found in the database", countryName, "Country is valid");

        }

        [TestMethod]
        public void GetLastEntryListOfCountryNamesByCode()
        {
            List<tCountryCodeAndName> countryNamesList = countryInfoServiceSoapType.ListOfCountryNamesByCode();

            var country = countryNamesList.Last();

            var countryName = countryInfoServiceSoapType.CountryName(country.sISOCode);

            Assert.AreEqual(country.sName, countryName, "Country don't match");

        }


    }
}
