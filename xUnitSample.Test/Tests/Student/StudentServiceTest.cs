using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using xUnitSample.Business.Abstract;
using xUnitSample.Model.Concrete;
using xUnitSample.Test.MockObjects;

namespace xUnitSample.Test.Tests.Student
{
    public class StudentServiceTest : IClassFixture<CustomWebApplicationFactory<Api.Startup>>
    {
        private readonly CustomWebApplicationFactory<Api.Startup> _factory;

        public StudentServiceTest(CustomWebApplicationFactory<Api.Startup> factory)
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

            studentService.Insert(studentModel);

            var createdStudentModel = studentService.GetById(id);

            Assert.Equal(studentModel, createdStudentModel);
        }

        [Theory, ClassData(typeof(MockStudentData))]
        public void InsertStudentWithClassData_ShouldAssertEqual(StudentModel model)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

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

            studentService.Insert(studentModel);

            var createdStudentModel = studentService.GetById(id);

            Assert.Equal(studentModel, createdStudentModel);
        }

        [Theory, MemberData(nameof(StaticParameter))]
        public void InsertStudentWithMemberData_ShouldAssertEqual(StudentModel model)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

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

            studentService.Insert(studentModel);

            var createdStudentModel = studentService.GetById(id);

            Assert.Equal(studentModel, createdStudentModel);
        }

        [Theory, InlineData(new object[] { "AAAAAAAA-BBBB-CCCC-DDDD-EEEEEEEEEEEE" })]
        public void GetStudentById_ShouldAssertNull(string Id)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var id = Guid.Parse(Id);
            var currentStudentModel = studentService.GetById(id);

            Assert.Null(currentStudentModel);
        }

        [Theory, InlineData(new object[] { "75D4CF4B-2BE8-47B3-8E72-2C9A59D0567B" })]
        public void DeleteStudent_ShouldAssertTrue(string Id)
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var id = Guid.Parse(Id);
            var studentModel = studentService.Delete(id);

            Assert.True(studentModel != null);
        }

        [Fact]
        public void GetAll_ShouldAssertTrue()
        {
            using var scope = _factory.Server.Host.Services.CreateScope();
            var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

            var studentModels = studentService.GetAll().ToList();

            Assert.True(studentModels.GetType().Equals(typeof(List<StudentModel>)));
        }
    }
}
