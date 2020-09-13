using System;
using Api.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Api.Data
{
    public class MongoDB
    {
        public IMongoDatabase db { get; }

        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var setting = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(setting);
                db = client.GetDatabase(configuration["DatabaseName"]);
                MapClasses();
            }
            catch (Exception err)
            {
                throw new MongoException("Não é possível se conectar ao MongoDB", err) ;
            }
        }

        private void MapClasses()
        {
            var convention = new ConventionPack {new CamelCaseElementNameConvention () };
            ConventionRegistry.Register("camelCase", convention, t => true);
            
            if(!BsonClassMap.IsClassMapRegistered(typeof(Infectado))){
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                {
                    i.AutoMap();                    
                    i.SetIgnoreExtraElements(true);
                });

            }
        }
    }
}