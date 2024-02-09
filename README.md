# RateLimiting

Rate limiting is a crucial aspect of web applications to prevent abuse, protect resources, and ensure fair usage. In the context of .NET Core, the `Microsoft.AspNetCore.RateLimiting middleware` provides rate limiting middleware with several options for implementing rate limiting. This document outlines four popular rate limiting techniques: Fixed Window, Sliding Window, Token Bucket, and Concurrency Limit.

# Rate Limiting Options in .NET Core Middleware

## 1. Fixed Window Rate Limiting
In fixed window rate limiting, a specific time window is defined, and the requests are counted within that window.

 **Implementation in .NET Core:**
  - Use the `RateLimitingMiddleware` and configure it with the fixed window strategy.
  - Set the window duration and request limit.

## 2. Sliding Window Rate Limiting
Sliding window rate limiting allows for a more dynamic approach by continuously tracking the requests within a moving time window..

 **Implementation in .NET Core:**
  -Utilize the `RateLimitingMiddleware` with the sliding window strategy.
  -Define window size and request limit.

## 3. Token Bucket Rate Limiting
Token bucket rate limiting involves tokens added to a bucket over time. Each request consumes a token, and if the bucket is empty, the request is denied..

- **Implementation in .NET Core:**
  - Integrate the `RateLimitingMiddleware` with the token bucket strategy.
  - Set the token replenishment rate and maximum tokens.
    
## 4. Concurrency Rate Limiting
The concurrency limiter limits the number of concurrent requests. Each request reduces the concurrency limit by one. When a request completes, the limit is increased by one. Unlike the other requests limiters that limit the total number of requests for a specified period, the concurrency limiter limits only the number of concurrent requests and doesn't cap the number of requests in a time period.

- **Implementation in .NET Core:**
  - Use the `RateLimitingMiddleware` and configure it with the concurrency limit strategy.
  - Specify the maximum allowed concurrent requests..
  
