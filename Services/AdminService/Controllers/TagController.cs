using API.Core;
using Code.Domain.Entities;
using Code.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    public class TagController : Controller
    {
        List<Tagsmodel> _tags = new List<Tagsmodel>();
        public TagController()
        {
            _tags = CommonFunctions.add_dummy_tag(_tags.Count + 1);
        }
        public IActionResult Index()
        {
            return View();
        }
        // POST api/<ProductController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] Tagsmodel model)
        {
            IActionResult response = BadRequest();
            model.Id = _tags.Count + 1;
            _tags.Add(model);
            response = Ok(new { InsertProductId = model.Id });
            return response;


        }
    }
}
