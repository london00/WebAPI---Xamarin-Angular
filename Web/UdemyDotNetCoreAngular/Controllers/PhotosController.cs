﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UdemyDotNetCoreAngular.Configuration;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController : BaseController
    {
        private readonly IHostingEnvironment host;
        private readonly IContext dbContext;
        private readonly IPhotoDAL photoDAL;
        private readonly PhotoSetting PhotoSetting;

        public PhotosController(IHostingEnvironment host, IMapper mapper, IContext dbContext, IPhotoDAL photoDAL, IOptionsSnapshot<PhotoSetting> options) : base(mapper)
        {
            this.host = host;
            this.dbContext = dbContext;
            this.photoDAL = photoDAL;
            this.PhotoSetting = options.Value;
        }

        [HttpPost]
        public async Task<ActionResult> Upload([FromRoute] int vehicleId, [FromForm] IFormFile file)
        {
            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty file");
            if (file.Length > PhotoSetting.MaxBytes) return BadRequest("File size exceeded");
            if(!PhotoSetting.IsSupported(Path.GetExtension(file.FileName))) return BadRequest("File extension not allowed");

            #region Copy photo to Server
            var uploadsFolderPath = Path.Combine(this.host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            #endregion

            #region Save photo path in database

            var photo = new Photo
            {
                FileName = fileName,
                VehicleId = vehicleId,
            };

            photoDAL.AddVehicle(photo);
            dbContext.CompleteChanges();

            #endregion

            return Ok(mapper.Map<Photo, PhotoDTO>(photo));
        }
    }
}