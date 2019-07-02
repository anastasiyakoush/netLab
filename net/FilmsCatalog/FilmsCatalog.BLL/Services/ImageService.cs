﻿using FilmsCatalog.BLL.Core.Interfaces;
using FilmsCatalog.DAL.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YandexDiskAPITransmitter.Interfaces;

namespace FilmsCatalog.BLL.Services
{
    public class ImageService : IImageService
    {
        private IUnitOfWork _uow;
        private IDiskAPI _diskApi;

        public ImageService(IUnitOfWork uow, IDiskAPI diskAPI)
        {
            _uow = uow;
            _diskApi = diskAPI;
        }

        public async Task<IEnumerable<string>> GetUrlsAsync(int filmId)
        {
            var publicUrls = await _uow.Images.GetAll()
                                   .Where(x => x.FilmId == filmId)
                                   .Select(x => x.Url)
                                   .ToListAsync();

            var urls = await _diskApi.GetDownloaderUrlsAsync(publicUrls);

            return urls;
        }
    }
}
