using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Test.MockObjects
{
    public class MockStudentData : TheoryData<StudentModel>
    {
        public MockStudentData()
        {
            Add(new StudentModel 
            { 
                IdentityNumber = "123456789",
                FirstName = "Emrah",
                LastName = "Şentürk",
                Email = "emsenturk@cits.com.tr",
                TelephoneNumber = null
            });

            Add(new StudentModel
            {
                IdentityNumber = "987654321",
                FirstName = "Ersin",
                LastName = "Yıldız",
                Email = "eryildiz@cits.com.tr",
                TelephoneNumber = "01237418529"
            });
        }
    }
}
