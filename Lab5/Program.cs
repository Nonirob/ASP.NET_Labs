using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync(@"
                                <html>
                                <head>
                                    <title>Cookie Form</title>
                                </head>
                                <body>
                                    <h1>Cookie Form</h1>
                                    <form method='post'>
                                        <label for='value'>Value:</label>
                                        <input type='text' id='value' name='value' /><br />
                                        <label for='expiryDate'>Expiry Date:</label>
                                        <input type='datetime-local' id='expiryDate' name='expiryDate' /><br />
                                        <button type='submit'>Submit</button>
                                    </form>
                                    <br />
                                    <a href='/checkcookie'>Check Cookie</a>
                                </body>
                                </html>
                            ");
                        });

                        endpoints.MapPost("/", context =>
                        {
                            var value = context.Request.Form["value"];
                            var expiryDate = DateTimeOffset.Parse(context.Request.Form["expiryDate"]);
                            context.Response.Cookies.Append("MyCookie", value, new CookieOptions
                            {
                                Expires = expiryDate.DateTime
                            });
                            return context.Response.WriteAsync("Data submitted successfully!");
                        });

                        endpoints.MapGet("/checkcookie", context =>
                        {
                            var cookieValue = context.Request.Cookies["MyCookie"];
                            return context.Response.WriteAsync($"Cookie Value: {cookieValue ?? "Not set"}");
                        });
                    });
                });
            });
}
