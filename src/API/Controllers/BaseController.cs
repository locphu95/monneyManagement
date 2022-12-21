using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IManager _repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;

        public BaseController(IManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
