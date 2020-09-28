using AutoMapper;
using MemeSharingAPI;
using MemeSharingAPI.Controllers;
using MemeSharingAPI.Data;
using MemeSharingAPI.Data.Dtos;
using MemeSharingAPI.Data.Repositories;
using MemeSharingAPI.Data.Repositories.Interfaces;
using MemeSharingAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MemeSharingApiUnitTests
{
    public class MemesControllerTest
    {
        private readonly HttpClient _client;
        public MemesControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Theory]
        [InlineData("api/memes")]
        public async Task GetAllMemes_ReturnsAllMemes_OkResponse(string url)
        {
            var response = await _client.GetAsync(url);

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("api/memes/", 1)]
        public async Task GetMemeById_ReturnsSingleMeme_OkResponse(string url, int id)
        {
            var response = await _client.GetAsync(url + id.ToString());

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("api/memes/", -1)]
        public async Task GetMemeById_MemeWillNotBeFound_NotFoundResponse(string url, int id)
        {
            var response = await _client.GetAsync(url + id.ToString());

            Assert.Equal("NotFound", response.StatusCode.ToString());
        }

    }
}
