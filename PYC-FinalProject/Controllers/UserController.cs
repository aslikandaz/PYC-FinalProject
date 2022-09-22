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
    public class UserController : ControllerBase
    {
        private readonly IMapperSession<User> _session;
        private readonly IMapperSession<Offer> _sessiono;
        private readonly IMapperSession<Product> _sessionp;


        public UserController(IMapperSession<User> session, IMapperSession<Offer> sessiono, IMapperSession<Product> sessionp)
        {
            _session = session;
            _sessiono = sessiono;
            _sessionp = sessionp;
        }

        [HttpGet("UsersBid")]
        public List<Offer> GetOfferableProducts()
        {
            var user = _session.Entites.Where(x => x.Status == true).First();
            List<Offer> result = _sessiono.Entites.Where(x => x.UserId == user.Id).ToList();
            return result;

        }

        [HttpGet("UsersProductOffers")]
        public List<Offer> GetOfferableProductss()
        {
            var user = _session.Entites.Where(x => x.Status == true).First();
            List<Product> result1 = _sessionp.Entites.Where(x=>x.UserId == user.Id).ToList();
            List<Offer> offerlist = new List<Offer>();
            foreach (var item in result1)
            {
                List<Offer> list = _sessiono.Entites.Where(x => x.ProductId == item.Id ).ToList();
                foreach (var items in list)
                {
                    offerlist.Add(items);
                }

                
            }
            return offerlist;

        }

        [HttpPost("AcceptOffer")]
        public IActionResult Post(int offerId)
        {
            Offer result = _sessiono.Entites.Where(x => x.Id == offerId).First();
            Product product = _sessionp.Entites.Where(x => x.Id == result.ProductId).First();
            var user = _session.Entites.Where(x => x.Status == true).First();
            try
            {
                _session.BeginTransaction();
                result.Id = result.Id;
                result.ProductId = result.ProductId;
                result.Proffer = result.Proffer;
                result.UserId = result.Id;
                result.Status = 2;

                product.UserId = user.Id;
                product.IsSold = true;

                _sessiono.Update(result);
                _sessionp.Update(product);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Offer Accept Error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok(result);
        }

        [HttpPost("RejectOffer")]
        public IActionResult PostReject(int offerId)
        {
            Offer result = _sessiono.Entites.Where(x => x.Id == offerId).First();
            try
            {
                _session.BeginTransaction();
                result.Id = result.Id;
                result.ProductId = result.ProductId;
                result.Proffer = result.Proffer;
                result.UserId = result.UserId;
                result.Status = 3;

                _sessiono.Update(result);
                _session.Commit();
            }
            catch (Exception ex)
            {
                _session.Rollback();
                Log.Error(ex, "Offer Reject Error");
            }
            finally
            {
                _session.CloseTransaction();
            }

            return Ok(result);
        }
    }
}
