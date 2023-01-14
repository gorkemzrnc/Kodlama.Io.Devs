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

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand:IRequest<UpdateProgramingLanguageDto>
    {
        public string Name { get; set; }

        public class UpdateProgramingLanguageHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdateProgramingLanguageDto>
        {

            private readonly IMapper _mapper;
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageHandler(ProgramingLanguageBusinessRules programingLanguageBusinessRules, IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdateProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request.Name);
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgramingLanguage);
                UpdateProgramingLanguageDto updateProgramingLanguage = _mapper.Map<UpdateProgramingLanguageDto>(updatedProgramingLanguage);

                return updateProgramingLanguage;

            }
        }
    } 
}
