using AutoMapper;
using Contacts.Core.Entities;
using Contacts.DTO.Requests;

namespace ContactsApi.MappingProfiles
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<CreateContactModel, Contact>();
            CreateMap<UpdateContactModel, Contact>();
        }
    }
}
