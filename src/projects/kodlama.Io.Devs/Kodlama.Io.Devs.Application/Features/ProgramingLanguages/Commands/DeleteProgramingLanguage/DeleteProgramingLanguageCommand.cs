using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand:IRequest<DeleteProgramingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramingHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeleteProgramingLanguageDto>
        {
            IMapper _mapper;
            IProgramingLanguageRepository _programingLanguageRepository;

            public DeleteProgramingHandler(IMapper mapper, IProgramingLanguageRepository programingLanguageRepository)
            {
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
            }

            public async Task<DeleteProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgramingLanguage mappedPrograingLanguage = _mapper.Map<ProgramingLanguage>(request.Id);
                ProgramingLanguage deletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(mappedPrograingLanguage);
                DeleteProgramingLanguageDto deleteProgramingLanguage = _mapper.Map<DeleteProgramingLanguageDto>(deletedProgramingLanguage);

                return deleteProgramingLanguage;

            }
        }
    }
}
