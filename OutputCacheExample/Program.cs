var builder = WebApplication.CreateBuilder(args);

var CacheExpirationInSeconds = builder.Configuration.GetValue<int>("Caching:CacheExpirationInSeconds");

builder.Services.AddOutputCache(o =>
{
    o.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(CacheExpirationInSeconds);
});

var app = builder.Build();

app.UseOutputCache();

app.MapGet("/test-outputcache/{id:int}", (int id) =>
{
    var cachedAt = DateTime.Now;
    var cachedUntil = cachedAt.AddSeconds(CacheExpirationInSeconds);
    
    return new
    {
        response = $"Response for Id {id} ...",
        cachedAt = cachedAt.ToLongTimeString(),
        cachedUntil = cachedUntil.ToLongTimeString(),
        cachedFor = $"{CacheExpirationInSeconds} seconds",
    };
})
.CacheOutput();

app.Run();
