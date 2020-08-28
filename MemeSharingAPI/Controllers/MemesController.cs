using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MemeSharingAPI.Data.Dtos;
using MemeSharingAPI.Data.Models;
using MemeSharingAPI.Data.Repositories.Interfaces;
using MemeSharingAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MemeSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepo;
        private readonly IMemeRepository _memeRepo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinarySettings;
        private Cloudinary _cloudinary;

        public MemesController(IPhotoRepository photoRepo, IMemeRepository memeRepo, IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _photoRepo = photoRepo;
            _memeRepo = memeRepo;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;

            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.APIKey,
                _cloudinarySettings.Value.APISecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeme([FromForm] MemeCreateDto memeCreateDto)
        {
            var photoFile = memeCreateDto.PhotoFile;

            var uploadResult = new ImageUploadResult();

            if (photoFile.Length <= 0)
                return BadRequest("Photo was not uploaded!");

            using(var stream = photoFile.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(photoFile.FileName, stream),
                    Transformation = new Transformation()
                        .Width(850).Height(850).Crop("fill").Gravity("face")
                };

                uploadResult = _cloudinary.Upload(uploadParams);
            }

            var photo = new Photo()
            {
                Url = uploadResult.Url.AbsoluteUri,
                DateAdded = memeCreateDto.DateAdded,
                PublicId = uploadResult.PublicId
            };

            await _photoRepo.AddPhoto(photo);
            if (!(await _photoRepo.Done()))
                return BadRequest("There was an error uploading the photo");

            var meme = new Meme()
            {
                Title = memeCreateDto.Title,
                DateAdded = memeCreateDto.DateAdded,
                PhotoId = photo.Id,
                MemeTypeId = memeCreateDto.MemeTypeId
            };

            await _memeRepo.AddMeme(meme);
            if (!(await _memeRepo.Done()))
                return BadRequest("There was an error uploading the meme");

            return CreatedAtRoute(nameof(GetMemeById), new { id = meme.Id }, meme);

        }
    }
}