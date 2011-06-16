using System;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.Services;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Lifebyte.Web.Tests.Models.Services
{
    [TestFixture]
    public class DataServiceTest
    {
        [Test]
        public void FindOne_ReturnsEntity()
        {
            var fakeVolunteer = new Volunteer
                                    {
                                        Id = Guid.NewGuid(),
                                        Username = "username",
                                        Password = "password"
                                    };

            var repository = new Mock<IRepository<Volunteer>>();

            repository.Setup(r => r.FindOne(v => v.Username == fakeVolunteer.Username
                                && v.Password == fakeVolunteer.Password))
                                .Returns(fakeVolunteer);
        }

        [Test]
        public void FindAll_ReturnsEntity()
        {
            var volunteers = new List<Volunteer>
                                 {
                                     new Volunteer
                                         {
                                             Id = Guid.NewGuid(),
                                             Username = "username",
                                             Password = "password",
                                         }
                                 };

            var repository = new Mock<IRepository<Volunteer>>();

            repository.Setup(r => r.FindAll(v => v.LastName == It.IsAny<string>()))
                                .Returns(volunteers);
        }

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