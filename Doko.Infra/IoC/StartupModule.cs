using System.Reflection;
using Autofac;
using Doko.Don.Interface;
using Doko.Don.Logic;
using Doko.Get.Interface;
using Doko.Get.Logic;
using Doko.Mongo.Collection;
using Doko.Mongo.Interface;
using MongoDB.Driver;

namespace Doko.Infra;

public class StartupModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(m =>
        {
            var connection = Environment.GetEnvironmentVariable("MONGO_CONN");
            var client = new MongoClient(connection);

            return client.GetDatabase("DokoDon");
        }).As<IMongoDatabase>().SingleInstance();

        builder.RegisterType<AnimeService>().As<IAnimeService>().InstancePerLifetimeScope();
        builder.RegisterType<PublicMyAnimeListApi>().As<IPublicMALApi>().InstancePerLifetimeScope();

        builder.RegisterType<AnimeCollection>().As<IAnimeCollection>().InstancePerLifetimeScope();
    }
}
