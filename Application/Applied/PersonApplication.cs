namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class PersonApplication: IPersons
{
    private readonly IPerson _iperson;

    public PersonApplication(IPerson iPerson)
    {
        _iperson=iPerson;
    }
    public string Add(Person person)
    {
        return _iperson.Add(person);
    }

    public string Delete(int id)
    {
       var person = GetById(id);
       return _iperson.Delete(person);
    }

    

   
    public Person Update(Person person, int id)
    {
       
    
 
  

 

   
        var personTo = GetById(id);
        personTo.code = person.code;
        personTo.type = person.type;
        personTo.firstName = person.firstName;
        personTo.MiddleName = person.MiddleName;
        personTo.LastName = person.LastName;
        personTo.Nationality = person.Nationality;
        personTo.DOB = person.DOB;
        personTo.title = person.title;
        personTo.gender = person.gender;
        personTo.preference = person.preference;
        personTo.isActive = person.isActive;
        personTo.remark = person.remark;
       
        return _iperson.Update(personTo);


    }

    public IReadOnlyList<Person> GetAll()
    {
        return _iperson.GetAll();
    }

    public Person GetById(int id)
    {
       return _iperson.GetById(id);
    }

  
}