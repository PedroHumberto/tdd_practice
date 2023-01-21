using CloudCustomers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCostumersUnitTest.Fixtures
{
    static class UsersFixture
    {
        public static List<Users> GetTestUsers() => new(){
                new Users
                    {
                        Id = 1,
                        Name = "Test",
                        Address = new Address
                        {
                            Street = "123 Main St",
                            City = "Madison",
                            ZipCode = "54658"
                        },
                        Email = "email@test.com"

                    },
                new Users
                    {
                        Id = 2,
                        Name = "Test 2",
                        Address = new Address
                        {
                            Street = "12312 Saint St",
                            City = "Louisiana",
                            ZipCode = "1231214"
                        },
                        Email = "email2@test.com"

                    },
                new Users
                    {
                        Id = 3,
                        Name = "Test 3",
                        Address = new Address
                        {
                            Street = "Lake St",
                            City = "Virginia",
                            ZipCode = "567812"
                        },
                        Email = "email3@test.com"

                    }
            };
    }
}
