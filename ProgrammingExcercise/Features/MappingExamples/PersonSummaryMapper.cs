using ProgrammingExercise.Features.MappingExamples.Models;

namespace ProgrammingExercise.Features.MappingExamples
{
    public class PersonSummaryMapper
    {

        public PersonSummary Map(Person person)
        {
            return new PersonSummary
            {
                FullName = $"{person.Title} {person.FirstName} {person.LastName}",
                Email = person.Email,
                IsManager = person.JobTitle == "Manager",
                Title = person.Title,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                City = person.City,
                State = person.State,
                PostalCode = person.PostalCode,
                Country = person.Country,
                JobTitle = person.JobTitle,
                IsATroubleMaker = person.Complaints?.Count > 5
            };
        }
    }
}
