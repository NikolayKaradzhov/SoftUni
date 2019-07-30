using Microsoft.Extensions.DependencyInjection;
using MuOnline.Core.Factories;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Items.Contracts;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories;
using MuOnline.Repositories.Contracts;

namespace MuOnline
{
    using System;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            //DI(Dependency Injection => following Open/Close principles in SOLID)
            //Repositories and Factories to be loaded.

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IItemFactory, ItemFactory>();
            serviceCollection.AddTransient<IMonsterFactory, MonsterFactory>();
            serviceCollection.AddTransient<IHeroFactory, HeroFactory>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddSingleton<IRepository<IHero>, HeroRepository>();
            serviceCollection.AddSingleton<IRepository<IMonster>, MonsterRepository>();
            serviceCollection.AddSingleton<IRepository<IItem>, ItemRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;

        }
    }
}
