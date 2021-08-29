using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADN.Domain.Ports;
using ADN.Domain.Entities;
using NSubstitute;
using ADN.Domain.Services;
using System.Threading.Tasks;
using ADN.Domain.Exceptions;

namespace ADN.Domain.Tests
{
    [TestClass]
    public class PersonServiceTest
    {

        IGenericRepository<Person> _personRepository;
        PersonService _personService;

        [TestInitialize]
        public void Init(){
            _personRepository = Substitute.For<IGenericRepository<Person>>();
            _personService = new PersonService(_personRepository);
        }

        [TestMethod, ExpectedException(typeof(UnderAgeException))]
        public async Task FailToRegisterAnUnderagePerson()
        {
            Person newborn = new()
            {
                FirstName = "john",
                LastName = "doe",
                Email = "johndoe@foo.bar",
                DateOfBirth = System.DateTime.Now
            };

            await _personService.RegisterPerson(newborn);
        }

        [TestMethod]
        public async Task SuccessToRegisterPerson()
        {
            Person older = new()
            {
                FirstName = "john",
                LastName = "doe",
                Email = "johndoe@foo.bar",
                DateOfBirth = System.DateTime.Now.AddYears(-20)
            };

            _personRepository.AddAsync(Arg.Any<Person>()).Returns(Task.FromResult(
                new PersonDataBuilder()
                    .WithName(older.FirstName)
                    .WithLastName(older.LastName)
                    .WithEmail(older.Email)
                    .WithDateOfBirth(older.DateOfBirth).Build()
            ));

            var result = await _personService.RegisterPerson(older);

            Assert.IsTrue(result is Person && result?.Id is not null);
        }
    }
}
