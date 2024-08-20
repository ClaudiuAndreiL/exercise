using AutoFixture;
using FluentAssertions;
using ProgrammingExercise.Features.MappingExamples;
using ProgrammingExercise.Features.MappingExamples.Models;
using System.Runtime.CompilerServices;
using Xunit;

namespace UnitTests.MappingExamples
{
    public class PersonSummaryMapperShould
    {
        private readonly Fixture _fixture = new();
        private readonly PersonSummaryMapper _personSummaryMapper;

        private readonly Person _defaultPerson;

        public PersonSummaryMapperShould()
        {
            _personSummaryMapper = new PersonSummaryMapper();
            _defaultPerson = _fixture.Create<Person>();
        }

        [Fact]
        public void MapPersonToPersonSummaryWhenIsManager()
        {
            // arrange
            _defaultPerson.JobTitle = "Manager";

            var expected = new PersonSummary
            {
                FullName = $"{_defaultPerson.Title} {_defaultPerson.FirstName} {_defaultPerson.LastName}",
                Email = _defaultPerson.Email,
                IsManager = true,
                Title = _defaultPerson.Title,
                PhoneNumber = _defaultPerson.PhoneNumber,
                Address = _defaultPerson.Address,
                City = _defaultPerson.City,
                State = _defaultPerson.State,
                PostalCode = _defaultPerson.PostalCode,
                Country = _defaultPerson.Country,
                JobTitle = _defaultPerson.JobTitle,
            };

            // act
            var mapped = _personSummaryMapper.Map(_defaultPerson);

            // assert
            mapped.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void MapPersonToPersonSummaryWhenIsNotManager()
        {
            // arrange
            _defaultPerson.JobTitle = "randomProgrammer";

            var expected = new PersonSummary
            {
                FullName = $"{_defaultPerson.Title} {_defaultPerson.FirstName} {_defaultPerson.LastName}",
                Email = _defaultPerson.Email,
                IsManager = false,
                Title = _defaultPerson.Title,
                PhoneNumber = _defaultPerson.PhoneNumber,
                Address = _defaultPerson.Address,
                City = _defaultPerson.City,
                State = _defaultPerson.State,
                PostalCode = _defaultPerson.PostalCode,
                Country = _defaultPerson.Country,
                JobTitle = _defaultPerson.JobTitle,
            };

            // act
            var mapped = _personSummaryMapper.Map(_defaultPerson);

            // assert
            mapped.Should().BeEquivalentTo(expected);
        }


        [Theory]
        [InlineData(5, false)]
        [InlineData(6, true)]
        public void MapPersonToPersonSummaryWhenIsATroubleMaker(int noOfComplaints, bool isTroubleMaker)
        {
            // arrange
            _defaultPerson.Complaints = Enumerable.Range(0, noOfComplaints).Select(x => x.ToString()).ToList();

            var expected = new PersonSummary
            {
                FullName = $"{_defaultPerson.Title} {_defaultPerson.FirstName} {_defaultPerson.LastName}",
                Email = _defaultPerson.Email,
                IsManager = isTroubleMaker,
                Title = _defaultPerson.Title,
                PhoneNumber = _defaultPerson.PhoneNumber,
                Address = _defaultPerson.Address,
                City = _defaultPerson.City,
                State = _defaultPerson.State,
                PostalCode = _defaultPerson.PostalCode,
                Country = _defaultPerson.Country,
                JobTitle = _defaultPerson.JobTitle,
            };

            // act
            var mapped = _personSummaryMapper.Map(_defaultPerson);

            // assert
            mapped.Should().BeEquivalentTo(expected);
        }
    }
}
