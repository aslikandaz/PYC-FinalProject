using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.Business.Validate;
using ProductCatalogue.DataAccess.Entites.Concrete;
using ProductCatalogue.DataAccess.Context;
using FluentValidation;
using Serilog;

namespace ProductCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMapperSession<Product> _session;

        public ProductController(IMapperSession<Product> session)
        {
            _session = session;
        }

        [HttpGet("GetAll")]
        public List<Product> Get()
        {
            List<Product> result = _session.GetAll().ToList();
            return result;
        }

        [HttpPost("Add")]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _session.BeginTransaction();
                try
                {
                    ProductValidator validator = new ProductValidator();
                    validator.ValidateAndThrow(product);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

                _session.Save(product);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Product Insert Error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok();
        }
    }
}
