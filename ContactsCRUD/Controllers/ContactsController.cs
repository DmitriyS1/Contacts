using System.Threading.Tasks;
using AutoMapper;
using Contacts.Core.Entities;
using Contacts.DTO.Requests;
using ContactsApi.Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ContactsApi.Controllers
{
    /// <summary>
    /// Контроллер для работы с контактами
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IMapper _mapper;

        public ContactsController(
            IContactsRepository contactsRepository,
            IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <response code="200">Информация о запрошенном контакте</resposne>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var contact = await _contactsRepository.GetAsync(new ObjectId(id));
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        /// <summary>
        /// Получить список контактов
        /// </summary>
        /// <response code="200">Список контактов</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactsRepository.GetAllAsync());
        }

        /// <summary>
        /// Создать контакт
        /// </summary>
        /// <param name="model">Модель для создания контакта</param>
        /// <response code="200">Контакт успешно создан</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactModel model)
        {
            var contact = _mapper.Map<Contact>(model);

            await _contactsRepository.CreateAsync(contact);

            return Ok();
        }

        /// <summary>
        /// Обновить информацию о контакте
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <param name="model">Модель для обновления контакта</param>
        /// <response code="200">Контакт успешно обновлен</response>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateContactModel model) /// JsonMergePatchDocument потому что если поле не передано, не надо обновлять
        {
            var updatedContact = _mapper.Map<Contact>(model);

            await _contactsRepository.UpdateAsync(updatedContact);

            return Ok();
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">Идентификатор удаляемого контакта</param>
        /// <response code="200">Контакт успешно удален</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _contactsRepository.DeleteAsync(new ObjectId(id));

            return Ok();
        }
    }
}