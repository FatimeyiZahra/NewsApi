using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Resources;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [Route("V1/News")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetAllOrderedAsync();

            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResources);

        }

        [Route("AllNews")]
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            var news = await _unitOfWork.News.GetAllNewWithCategories();
            //var newss = await _unitOfWork.News.GetNews();
            var newsResources = _mapper.Map<IEnumerable<News>, IEnumerable<NewsResource>>(news);

            return Ok(newsResources);

        }


        //------------------------- All News By Category Id ----------------------
        [Route("category")]
        [HttpGet]
        public async Task<IActionResult> GetNewsByCategory([FromQuery] int categoryId)
        {

            var category = await _unitOfWork.Category.GetByIdAsync(categoryId);

            if (category == null) return NotFound();

            var news = await _unitOfWork.News.GetNewsByCategoryId(categoryId);

            var newsResources = _mapper.Map<IEnumerable<News>, IEnumerable<NewsResource>>(news);
            return Ok(newsResources);
               

        }

        //------------news by id ----------------------

        [Route("news/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _unitOfWork.News.GetNewsById(id);

            if (news == null) return NotFound();

            var newsResource = _mapper.Map<News, NewsResource>(news);

            return Ok(newsResource);
        }
    }
}
