using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebAPI
{
    public class RepeatingService:BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly HttpClient _httpClient;

        public RepeatingService(IServiceScopeFactory scopeFactory, HttpClient httpClient)
        {
            _scopeFactory = scopeFactory;
            _httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var apiKey = "db000f74554aea70f2e18e0b3928ec71";
                var baseUrl = "https://api.themoviedb.org/3/trending/all/day";
                var url = $"https://api.themoviedb.org/3/trending/all/day?api_key={apiKey}";

                using (var response = await _httpClient.GetAsync(url, stoppingToken))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync(stoppingToken);
                        var result = JsonConvert.DeserializeObject<MovieResult>(content);

                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();

                            foreach (var movie in result.Results)
                            {
                                dbContext.Movies.Add(movie);
                            }

                            await dbContext.SaveChangesAsync(stoppingToken);
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }


    }

   
}
