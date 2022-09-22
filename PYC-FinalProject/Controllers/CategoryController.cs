using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductCatalogue.Business.Validate;
using ProductCatalogue.DataAccess.Entites.Concrete;
using ProductCatalogue.DataAccess.Context;
using Serilog;

namespace ProductCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapperSession<Category> _session;

        public CategoryController(IMapperSession<Category> session)
        {
            _session = session;
        }

        [HttpGet("GetAll")]
        public List<Category> Get()
        {
            List<Category> result = _session.GetAll().ToList();
            return result;
        }

        [HttpPost("Add")]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _session.BeginTransaction();
                try
                {
                    CategoryValidator validator = new CategoryValidator();
                    validator.ValidateAndThrow(category);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

                _session.Save(category);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Category Insert Error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult<Category> Put([FromBody] Category request)
        {
            Category category = _session.Entites.Where(x => x.Id == request.Id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                _session.BeginTransaction();

                category.Id = category.Id;
                category.Name = request.Name;

                try
                {
                    CategoryValidator validator = new CategoryValidator();
                    validator.ValidateAndThrow(category);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                
                _session.Update(category);

                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Category Update Error");
            }
            finally
            {
                _session.CloseTransaction();
                
            }

            return Ok();
        }
    }
}
