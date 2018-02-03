using System;
using System.Data.SqlClient;
using Ganhua.Concurrency.Model;
using Ganhua.Concurrency.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ganhua.Concurrency.Test
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private static string _dbConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\People.mdf;Integrated Security=True";

        private static Guid _personId = new Guid("0b7f95b0-be8b-4758-a994-c4ab81d33b40");

        [TestInitialize]
        public void Clean_The_Database_Then_Add_A_Test_Person()
        {
            string assemblyPath = this.GetType().Assembly.Location;
            var assemblyDirectory = System.IO.Directory.GetParent(assemblyPath);
            var projectDirectory = assemblyDirectory.Parent.Parent;
            _dbConnectionString = string.Format(_dbConnectionString, projectDirectory.FullName);

            //清除所有資料
            using (SqlConnection connection =
                      new SqlConnection(_dbConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE People";
                connection.Open();
                command.ExecuteNonQuery();
            }

            IPersonRepository personRepository = new PersonRepository(_dbConnectionString);

            Person personToAdd = new Person();
            personToAdd.FirstName = "Lynsey";
            personToAdd.LastName = "Millett";
            personToAdd.Id = _personId;
            personToAdd.Version = 1;

            //新增一筆資料
            personRepository.Add(personToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void An_Exception_Will_Be_Thrown_When_Trying_To_Update_A_Modified_Person()
        {
            IPersonRepository personRepository = new PersonRepository(_dbConnectionString);

            Person personToChangeA = personRepository.FindBy(_personId);
            Person personToChangeB = personRepository.FindBy(_personId);

            Assert.AreEqual(personToChangeA.Version, personToChangeB.Version);

            personToChangeA.FirstName = "Doris";
            // Once the person is saved the version number is generated
            personRepository.Save(personToChangeA);

            Assert.AreNotEqual(personToChangeA.Version, personToChangeB.Version);

            // This person is now stale and has an old version number
            // saving this person will cause an exception to be thrown.
            personToChangeB.FirstName = "Dasiy";
            personRepository.Save(personToChangeB);
        }
    }
}
