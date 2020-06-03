using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_ShopMicroservice.Microservices.ProductService.Domain.Entities;
using E_ShopMicroservices.Data.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_ShopMicroservice.Microservices.ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiController
    {
        public ProductsController()
        {

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return new List<Product>();
        }
    }
}