using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.Business.Validate;
using ProductCatalogue.DataAccess.Entites.Concrete;
using ProductCatalogue.DataAccess.Context;
using Serilog;
using FluentValidation;

namespace ProductCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMapperSession<Offer> _session;
        private readonly IMapperSession<Product> _sessionp;
        private readonly IMapperSession<User> _sessionu;

        public OfferController(IMapperSession<Offer> session, IMapperSession<Product> sessionp, IMapperSession<User> sessionu)
        {
            _session = session;
            _sessionp = sessionp;
            _sessionu = sessionu;
        }

        [HttpGet("GetOfferableProducts")]
        public List<Product> Get()
        {
            List<Product> result = _sessionp.Entites.Where(x=>x.IsOfferable == true).ToList();
            return result;
        }

        [HttpPost("Bidding")]
        public IActionResult Post(int bid,int productId)
        {
            try
            {
                _session.BeginTransaction();

                var product = _sessionp.Entites.Where(x => x.Id == productId).First();
                var user = _sessionu.Entites.Where(x => x.Status == true).First();

                if (product.IsOfferable == true)
                {
                    Offer offer = new Offer();
                    offer.ProductId = productId;
                    offer.UserId = user.Id;
                    offer.Proffer = bid;
                    _session.Save(offer);
                    _session.Commit();
                }
                else
                {
                    return BadRequest("This product cannot be bid");
                }
                
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Bidding Error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok();
        }

        [HttpPost("Buy")]
        public IActionResult Post( int productId)
        {
            try
            {
                _session.BeginTransaction();

                var product = _sessionp.Entites.Where(x => x.Id == productId).First();
                var user = _sessionu.Entites.Where(x => x.Status == true).First();

                if (product.IsSold == false)
                {
                    Product newproduct = new Product();
                    newproduct.Id = product.Id;
                    newproduct.CategoryId = product.CategoryId;
                    newproduct.Brand = product.Brand;
                    newproduct.Color = product.Color;
                    newproduct.Description = product.Description;
                    newproduct.Name = product.Name;
                    newproduct.Price = product.Price;
                    newproduct.IsOfferable = false;
                    newproduct.IsSold = true;
                    newproduct.UserId = user.Id;

                   _sessionp.Save(newproduct);
                   _sessionp.Delete(product); 
                   _session.Commit();
                }
                else
                {
                    return BadRequest("This product cannot be puchased");
                }

            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Product purchase error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok();
        }
    }
}

