using System;
using System.Collections.Generic;
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

            repository.Setup(r => r.SelectAll(v => v.LastName == It.IsAny<string>(), 
                order => order.FirstName, 0, 100)).Returns(volunteers);
        }

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

            repository.Setup(r => r.SelectOne(v => v.Username == fakeVolunteer.Username
                                                 && v.Password == fakeVolunteer.Password))
                .Returns(fakeVolunteer);
        }

        [Test]
        public void Save_WasCalled()
        {
            var fakeVolunteer = new Volunteer();
            var repository = new Mock<IRepository<Volunteer>>();

            repository.Setup(r => r.Insert(It.IsAny<Volunteer>(), It.IsAny<object>())).Verifiable();

            var dataService = new DataService<Volunteer>(repository.Object);

            dataService.Insert(fakeVolunteer, fakeVolunteer.Id);

            repository.Verify();
        }
    }
}