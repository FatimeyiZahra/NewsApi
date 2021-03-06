using Api.Resources;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mapping
{
    public class ProfileMapping : Profile
    {
        private static string BaseUrl = "https://localhost:44313/img/";

        public ProfileMapping()
        {

            CreateMap<Category, CategoryResource>();


            //CreateMap<NewsResource, NewsCategory>();
            //CreateMap<NewsCategory, NewsResource>();


            CreateMap<News, NewsResource>()
               .ForMember(d => d.Photos, opt => opt.MapFrom(src => src.NewsPhotos
                                                                            .Select(p => BaseUrl + p.Photo)
                                                                            .ToArray()))

              .ForMember(d => d.Category, opt => opt.MapFrom(src => src.NewsCategories.FirstOrDefault().Category))

                .ForMember(n => n.CategoryName, opt => opt.MapFrom(src => src.NewsCategories
                                                                      .Select(s => s.Category.Name)
                                                                      .ToList()))
              .ForMember(n => n.CategoryId, opt => opt.MapFrom(src => src.NewsCategories
                                                                      .Select(s => s.Category.Id)
                                                                      .ToList()));

        }

    }
}

