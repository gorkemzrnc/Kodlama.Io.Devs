using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Models;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreateProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("",result);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdateProgramingLanguageDto result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeleteProgramingLanguageDto result = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList2([FromQuery] GetListProgramingLanguageQuery getListProgramingLanguageQuery)
        {
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            ProgramingLanguageGetByIdDto result = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(result);
        }

    }
}
