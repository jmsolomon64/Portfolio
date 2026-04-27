using MagicBL;
using MagicDbContext;
using PortfolioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : BaseController
    {
        private readonly ElementBL _element;
        public ElementController(ElementBL element)
        {
            _element = element;
        }

        [HttpGet(Name = "GetElements")]
        public Response<IEnumerable<Element>> Get() => HandleRequest(() => _element.GetElements());

        [HttpGet("{id}")]
        public Response<Element?> Get(int id) => HandleRequest(() => _element.GetElementById(id));
    }
}
