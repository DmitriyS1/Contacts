using System.Threading.Tasks;
using AutoMapper;
using Contacts.Core.Entities;
using Contacts.DTO.Requests;
using Contacts.DTO.Responses;
using ContactsApi.Dal.Repositories.Interfaces;
using ContactsApi.Exeptions;
using ContactsApi.Services;
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
        private readonly IContactsService _contactsService;
        private readonly IMapper _mapper;

        public ContactsController(
            IContactsRepository contactsRepository,
            IContactsService contactsService,
            IMapper mapper)
        {
            _contactsRepository = contactsRepository;
            _contactsService = contactsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <response code="200">Информация о запрошенном контакте</resposne>
        /// <response code="404">Контакт не найден</resposne>
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
        /// <response code="422">Ошибка в одном или нескольких параметрах</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }

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
        /// <response code="404">Контакт не найден</response>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateContactModel model) /// JsonMergePatchDocument потому что если поле не передано, не надо обновлять
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            ObjectId updatedId;
            try
            {
                updatedId = await _contactsService.UpdateAsync(new ObjectId(id), model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok(new ContactResponse { Id = updatedId });
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">Идентификатор удаляемого контакта</param>
        /// <response code="200">Контакт успешно удален</response>
        /// <response code="404">Контакт не найден</response>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                await _contactsService.DeleteAsync(new ObjectId(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}