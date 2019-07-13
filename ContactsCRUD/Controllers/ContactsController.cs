using System.Threading.Tasks;
using Contacts.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// Получить контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <response code="200">Информация о запрошенном контакте</resposne>
        [ProducesResponseType(200, Type = typeof(ContactInfoResponse))]
        [ProducesResponseType(404, Type = typeof(ApiError))]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return View();
        }

        /// <summary>
        /// Получить список контактов
        /// </summary>
        /// <response code="200">Список контактов</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View();
        }

        /// <summary>
        /// Создать контакт
        /// </summary>
        /// <param name="model">Модель для создания контакта</param>
        /// <response code="200">Контакт успешно создан</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactModel model)
        {
            return View();
        }

        /// <summary>
        /// Обновить информацию о контакте
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <param name="model">Модель для обновления контакта</param>
        /// <response code="200">Контакт успешно обновлен</response>
        [HttpPatch]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactModel model) /// JsonMergePatchDocument потому что если поле не передано, не надо апдейтить
        {
            return View();
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id">Идентификатор удаляемого контакта</param>
        /// <response code="200">Контакт успешно удален</response>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return View();
        }
    }
}