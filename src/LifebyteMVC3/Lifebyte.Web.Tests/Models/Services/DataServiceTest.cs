using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.Services;
using Moq;
using NUnit.Framework;

namespace Lifebyte.Web.Tests.Models.Services
{
    [TestFixture]
    public class DataServiceTest
    {
        [Test]
        public void Save_WasCalled()
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