var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("sqlsvr2d6")
                   //.WithPhpMyAdmin()
                   .WithLifetime(ContainerLifetime.Persistent);

var db2d6 = mysql.AddDatabase("db2d6");

mysql.WithInitFiles("../../database/scripts");

var dab = builder.AddDataAPIBuilder("dab", ["../../database/dab-config.json"])
                                .WithReference(db2d6)
                                .WithEnvironment(context =>
                                {
                                        context.EnvironmentVariables["ConnectionStrings__db2d6"] =
                                                $"Server={mysql.Resource.Name};User ID=root;Password={mysql.Resource.PasswordParameter.Value};Database=db2d6";
                                })
                                .WaitFor(db2d6);

builder.AddProject<Projects._2d6_dungeon_web_client>("webapp")
        .WaitFor(dab)
        .WithReference(dab)
        .WithExternalHttpEndpoints();

builder.Build().Run();
