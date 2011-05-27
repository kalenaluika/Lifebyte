using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Services;
using NUnit.Framework;
using Moq;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Tests.Models.Services
{
    [TestFixture]
    public class DataServiceTest
    {
        [Test]
        public void DataService_Save_SaveWasCalled()
        {
            var fakeVolunteer = new Volunteer();
            var repository = new Mock<IRepository<Volunteer>>();

            repository.Setup(r => r.Save(It.IsAny<Volunteer>())).Verifiable();

            var dataService = new DataService<Volunteer>(repository.Object);

            dataService.Save(fakeVolunteer);

            repository.Verify();
        }
    }
}