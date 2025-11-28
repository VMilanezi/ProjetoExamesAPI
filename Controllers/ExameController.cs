using Exames.API.Dtos;
using Exames.API.Models;
using Exames.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController(IExameService exameService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ExameModel>>>> GetAll()
        {
            var response = await exameService.GetAllExamesAsync();
            return response.isSuccess ? Ok(response) : NotFound(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseModel<ExameModel>>> Get(int id)
        {
            var response = await exameService.GetExameByIdAsync(id);
            return response.isSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ExameModel>>> Create([FromBody] CreateExameDto dto)
        {
            var response = await exameService.CreateExameAsync(dto);
            return response.isSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ResponseModel<ExameModel>>> Update(int id, [FromBody] UpdateExameDto dto)
        {
            var response = await exameService.UpdateExameAsync(id, dto);
            return response.isSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseModel<ExameModel>>> Delete(int id)
        {
            var response = await exameService.DeleteExameAsync(id);
            return response.isSuccess ? NoContent() : BadRequest(response);
        }
    }
}
