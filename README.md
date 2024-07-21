# OutputCache for WebAPI

1. Add OutputCache to DI container
   <pre>builder.Services.AddOutputCache(configureOptions)</pre>

3. Add OutputCache to middleware
   <pre>app.UseOutputCache()</pre>

5. Apply caching to endpoints
   <pre>
   Use method '.CacheOutput()' for minimal endpoints
   or Attribute '[CacheOutput]' in controllers
   </pre>
  
