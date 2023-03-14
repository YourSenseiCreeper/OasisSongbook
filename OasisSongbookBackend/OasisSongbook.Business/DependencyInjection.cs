using Microsoft.Extensions.DependencyInjection;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Services;
using OasisSongbook.Business.Services.Interfaces;

namespace OasisSongbook.Business
{
    public static class DependencyInjection
    {
        public static void AddBusiness(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<OasisSongbookNoSqlContext>();

            serviceCollection.AddScoped<IDocxTemplateService, DocxTemplateService>();
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IUserSevice, UserService>();
            serviceCollection.AddSingleton<ICryptoService, CryptoService>();
        }
    }
}
