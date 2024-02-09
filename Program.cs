using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(ratelimter =>
{
    ratelimter.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    // Fixed Window
    ratelimter.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(5);
        options.PermitLimit = 2;
        options.QueueLimit = 0;
    });

    // Sliding Window
    ratelimter.AddSlidingWindowLimiter("sliding", options =>
    {
        options.Window = TimeSpan.FromSeconds(5);
        options.PermitLimit = 2;
        options.QueueLimit = 2;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.SegmentsPerWindow = 2;        
    });

    // Token Bucket
    ratelimter.AddTokenBucketLimiter("token", options =>
    {
        options.TokenLimit = 2;
        options.QueueLimit = 2;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(5);
        options.TokensPerPeriod = 2;
        options.AutoReplenishment = true;
    });

    //Concurrency
    ratelimter.AddConcurrencyLimiter("concurrency", options =>
    {
        options.PermitLimit = 2;
        options.QueueLimit = 2;
        options.QueueProcessingOrder= QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
