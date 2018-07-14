using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yStore.Model.Models;
using yStore.Web.Models;

namespace yStore.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
            });
           /*
            IMapper mapper = config.CreateMapper();
            var source = new Post();
            var dest = mapper.Map<Post, PostViewModel>(source);
           */
        }
    }
}