var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("sqlsvr2d6")
                   //.WithPhpMyAdmin()
                   .WithLifetime(ContainerLifetime.Persistent);

var db2d6 = mysql.AddDatabase("db2d6");

//mysql.WithInitBindMount(source: "../../database/scripts", isReadOnly: false);
mysql.WithInitFiles("../../database/scripts");

var dab = builder.AddDataAPIBuilder("dab", ["../../database/dab-config.json"])
                .WithReference(db2d6)
                .WaitFor(db2d6);

builder.AddProject<Projects._2d6_dungeon_web_client>("webapp")
        .WaitFor(dab)
        .WithReference(dab)
        .WithExternalHttpEndpoints();

builder.Build().Run();
