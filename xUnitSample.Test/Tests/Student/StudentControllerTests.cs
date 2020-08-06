using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using xUnitSample.Api.Controllers;
using xUnitSample.Business.Abstract;
using xUnitSample.Model.Concrete;
using xUnitSample.Test.MockObjects;

namespace xUnitSample.Test.Tests.Student
{
    public class StudentControllerTests : IClassFixture<CustomWebApplicationFactory<Api.Startup>>
    {
        public CustomWebApplicationFactory<Api.Startup> _factory;

        public StudentControllerTests(CustomWebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
            _factory.CreateClient();
        }

        public static IEnumerable<object[]> StaticParameter => new List<StudentModel[]>
        {
            new StudentModel[]
            {
                new StudentModel
                {
                    IdentityNumber = "741852963",
                    FirstName = "Aykut",
                    LastName = "Şen",
                    Email = "ayksen@cits.com.tr",
                    TelephoneNumber = null
                },
                new StudentModel
                {
                    IdentityNumber = "963852741",
                    FirstName = "Serkan",
                    LastName = "Çetintaş",
                    Email = "scetintas@cits.com.tr",
                    TelephoneNumber = null
                }
            }
        };

        [Theory, InlineData(new object[] { "123456789", "Emrah", "Şentürk", "emsenturk@cits.com.tr", null })]
        public void InsertStudent_ShouldAssertEqual(
            string identityNumber,
            string firstName,
            string lastName,
            string email,
            string telephoneNumber)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var id = Guid.NewGuid();
            var studentModel = new StudentModel()
            {
                Id = id,
                IdentityNumber = identityNumber,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                TelephoneNumber = telephoneNumber,
            };

            var result = studentController.Post(studentModel);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Theory, ClassData(typeof(MockStudentData))]
        public void InsertStudentWithClassData_ShouldAssertEqual(StudentModel model)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var id = Guid.NewGuid();
            var studentModel = new StudentModel()
            {
                Id = id,
                IdentityNumber = model.IdentityNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                TelephoneNumber = model.TelephoneNumber,
            };

            var result = studentController.Post(studentModel);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Theory, MemberData(nameof(StaticParameter))]
        public void InsertStudentWithMemberData_ShouldAssertEqual(StudentModel model)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var id = Guid.NewGuid();
            var studentModel = new StudentModel()
            {
                Id = id,
                IdentityNumber = model.IdentityNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                TelephoneNumber = model.TelephoneNumber,
            };

            var result = studentController.Post(studentModel);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Theory, InlineData(new object[] { "AAAAAAAA-BBBB-CCCC-DDDD-EEEEEEEEEEEE" })]
        public void GetStudentById_ShouldAssertNull(string Id)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var id = Guid.Parse(Id);
            var currentStudentModel = studentController.GetById(id);

            Assert.Null(currentStudentModel);
        }

        [Theory, InlineData(new object[] { "75D4CF4B-2BE8-47B3-8E72-2C9A59D0567B" })]
        public void DeleteStudent_ShouldAssertTrue(string Id)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var id = Guid.Parse(Id);
            var result = studentController.Delete(id);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void GetAll_ShouldAssertTrue()
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentController = new StudentController(studentService);

            var studentModels = studentController.GetAll().ToList();

            Assert.True(studentModels.GetType().Equals(typeof(List<StudentModel>)));
        }
    }
}
