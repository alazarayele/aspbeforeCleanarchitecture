namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class CarrierApplication : Icarrier
{
    private readonly ICareer _iCareer;

    public CarrierApplication(ICareer icareer)
    {
        _iCareer = icareer;
    }

    public IReadOnlyList<Career> GetAll()
    {
        return _iCareer.GetAll();
    }

    public Career GetById(int id)
    {
        return _iCareer.GetById(id);
    }

    public string Add(Career career)
    {
        return _iCareer.Add(career);
    }
    public string Delete(int id)
    {
        var career = GetById(id);
        return _iCareer.Delete(career);
    }

    public Career Update(Career career, int id)
    {
        var careerTo = GetById(id);
        careerTo.type = career.type;
        careerTo.Careerperson = career.Careerperson;
        careerTo.index = career.index;
        careerTo.organization = career.organization;
        careerTo.field = career.field;
        careerTo.level = career.level;
        careerTo.startdate = career.startdate;
        careerTo.endDate = career.endDate;
        careerTo.award = career.award;
        careerTo.note = career.note;
        careerTo.remark = career.remark;
        return _iCareer.Update(careerTo);

    }
}