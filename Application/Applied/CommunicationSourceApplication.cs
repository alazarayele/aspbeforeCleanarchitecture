namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class CommunicationSourceApplication : ICommunicationSources
{
    private readonly ICommunicationSource _iCommunication;

    public CommunicationSourceApplication(ICommunicationSource icommunication)
    {
        _iCommunication = icommunication;
    }
     public IReadOnlyList<CommunicationSource> GetAll()
    {
        return _iCommunication.GetAll();
    }
    
    public CommunicationSource GetById(int id)
    {
        return _iCommunication.GetById(id);
    }

    public string Add(CommunicationSource communicationSource)
    {
        return _iCommunication.Add(communicationSource);
    }
    public string Delete(int id)
    {
        var communicationSource = GetById(id);
        return _iCommunication.Delete(communicationSource);
    }

    public CommunicationSource Update(CommunicationSource communicationSource, int id)
    {
        var communicationSource1 = GetById(id);
        communicationSource1.code = communicationSource.code;
        communicationSource1.CommunicationSourceperson = communicationSource.CommunicationSourceperson;
        communicationSource1.type = communicationSource.type;
        communicationSource1.communicatedBy = communicationSource.communicatedBy;
        communicationSource1.remark = communicationSource.remark;
        return _iCommunication.Update(communicationSource1);
    }
}