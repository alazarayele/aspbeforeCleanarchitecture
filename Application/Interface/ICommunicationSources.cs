namespace asp.Application.Interface;
using asp.Model;

public interface ICommunicationSources

{
    IReadOnlyList<CommunicationSource> GetAll();

    CommunicationSource GetById(int id);

    string Add(CommunicationSource communicationSource);

    string Delete(int id);

    CommunicationSource Update(CommunicationSource communicationSource, int id);
}