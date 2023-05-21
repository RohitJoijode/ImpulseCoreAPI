using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI
{
    public static class ServiceExtensions
    {
        //public static IMvcBuilder AddMyLibrary(this IMvcBuilder builder)
        //{
        //    builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    builder.AddJsonOptions(options =>
        //    {
        //        options.JsonSerializerOptions = new DefaultContractResolver()
        //        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        //    });
        //    builder.Services.ConfigureOptions<ConfigureLibraryOptions>();

        //    return builder;
        //}
    }
}
