using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;
using System.Threading.Tasks;

namespace WebsitePerformance.Bll.Services
{
    public class WebpageService : AbstractService<WebpageModel, Webpage>, IWebpageService
    {
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IWebpageRepository _webpageRepository;
        public WebpageService(IWebsiteRepository websiteRepository, IWebpageRepository webpageRepository, IMapper mapper) : base(webpageRepository, mapper)
        {
            _websiteRepository = websiteRepository;
            _webpageRepository = webpageRepository;
        }

        public override async Task<int> CreateAsync(WebpageModel model)
        {
            if (!await _websiteRepository.IsExistsAsync(model.Website.Id))
            {
                throw new Exception("Website is not exist");
            }

            var WebpageEntity = _mapper.Map<Webpage>(model);
            WebpageEntity.Website = null;

            return await _repository.CreateAsync(WebpageEntity);
        }

        public async Task<IEnumerable<WebpageModel>> GetByWebsiteAsync(int websiteId, int skip, int top)  =>
            (await ((IWebpageRepository)_repository).GetByWebsiteAsync(websiteId, skip, top)).Select(x => _mapper.Map<Webpage, WebpageModel>(x));
    }
}
