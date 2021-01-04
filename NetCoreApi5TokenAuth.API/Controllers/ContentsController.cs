using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi5TokenAuth.Core.DTOs;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;
using NetCoreApi5TokenAuth.Core.Services.Abstract;

namespace NetCoreApi5TokenAuth.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : BaseController
    {
        private IGenericService<Content, ContentDto> _contentService;

        public ContentsController(IGenericService<Content, ContentDto> contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contentList = await _contentService.GetAllAsync();

            return ActionResultInstance(contentList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var content = await _contentService.GetByIdAsync(id);

            return ActionResultInstance(content);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContentDto contentDto)
        {
            var newContent = await _contentService.AddAsync(contentDto);

            return ActionResultInstance(newContent);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContentDto contentDto)
        {
            var updatedContent = await _contentService.Update(contentDto, contentDto.Id);

            return ActionResultInstance(updatedContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var removedContent = await _contentService.Remove(id);

            return ActionResultInstance(removedContent);
        }
    }
}
