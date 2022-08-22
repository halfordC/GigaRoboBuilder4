using GigaRoboBuilder4.Data;
using GigaRoboBuilder4.Data.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000", "http://appname.azuerstaticapps.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( SwaggerGenOptions => 
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "GigaRoboBuilder", Version = "v1" });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( swaggerUiOptions =>
{
    swaggerUiOptions.DocumentTitle = "GigaRobo Builder Backend";
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "The backed to the Giga-Robo build sharing website");
    swaggerUiOptions.RoutePrefix = String.Empty;

});

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");


//================================================Robot section
app.MapGet("/getAllRobots", async () => await RobotRepository.GetRobotsAsync())
    .WithTags("Robot Endpoints");

app.MapGet("/getRobotById/{robotId}", async (int robotId) => 
{
    Robot robotToRetun = await RobotRepository.GetRobotById(robotId);

    if (robotToRetun != null)
    {
        return Results.Ok(robotToRetun);
    }
    else 
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Endpoints");

/* 
 * //We only ever need to Get robots, and never need to create / update / or delete. We'll handle that with our Json files / Seed Data.
//Or through an admin console later. For now, we only need the Gets for all of these.
app.MapPost("/createRobot", async (Robot robotToCreate) =>
{
    bool createSuccessful  = await RobotRepository.CreateRobotAsync(robotToCreate);


    if (createSuccessful)
    {
        return Results.Ok("Create Robot successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Endpoints");

app.MapDelete("/deleteRobotById/{robotId}", async (int robotId) =>
{
    bool deleteSuccessful = await RobotRepository.DeleteRobotAsync(robotId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete Robot successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Endpoints");
*/
//================================================Pilot section
app.MapGet("/getAllPilots", async () => await PilotRepository.GetPilotsAsync())
    .WithTags("Pilot Endpoints");

app.MapGet("/getPilotById/{pilotId}", async (int pilotId) =>
{
    Pilot pilotToRetun = await PilotRepository.GetPilotByIdAsync(pilotId);

    if (pilotToRetun != null)
    {
        return Results.Ok(pilotToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Pilot Endpoints");

/*
app.MapPost("/createPilot", async (Pilot pilotToCreate) =>
{
    bool createSuccessful = await PilotRepository.CreatePilotAsync(pilotToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create Pilot successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Endpoints");

app.MapDelete("/deletePilotById/{pilotId}", async (int pilotId) =>
{
    bool deleteSuccessful = await PilotRepository.DeletePilotAsync(pilotId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete Pilot successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Pilot Endpoints");
*/

//================================================Robot Ability section
app.MapGet("/getAllRobotAbilites", async () => await RobotAbilityRepository.GetRobotAbilitiesAsync())
    .WithTags("Robot Ability Endpoints");

app.MapGet("/getRobotAbilityById/{robotAbilityId}", async (int robotAbilityId) =>
{
    RobotAbility robotAbilityToRetun = await RobotAbilityRepository.GetRobotAbilityByIdAsync(robotAbilityId);

    if (robotAbilityToRetun != null)
    {
        return Results.Ok(robotAbilityToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Ability Endpoints");


app.MapGet("/getRobotAbilitiesByRobot/{robotId}", async (int robotId) =>
{
    var robotAbilityList = await RobotAbilityRepository.GetRobotAbilitiesByRobotIdAsync(robotId);

    if (robotAbilityList != null)
    {
        return Results.Ok(robotAbilityList);
    }
    else 
    {
        return Results.BadRequest();
    }
}).WithTags("Robot Ability Endpoints");

/*
app.MapPost("/createRobotAbility", async (RobotAbility robotAbilityToCreate) =>
{
    bool createSuccessful = await RobotAbilityRepository.CreateRobotAbilityAsync(robotAbilityToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create Robot Ability successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Endpoints");

app.MapDelete("/deleteRobotAbilityById/{robotAbilityId}", async (int robotAbilityId) =>
{
    bool deleteSuccessful = await RobotAbilityRepository.DeleteRobotAbilityAsync(robotAbilityId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete Robot Ability successful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Ability Endpoints");
*/

//================================================Pilot Ability section
app.MapGet("/getAllPilotAbilites", async () => await PilotAbilityRepository.GetPilotAbilitiesAsync())
    .WithTags("Pilot Ability Endpoints");

app.MapGet("/getPilotAbilityById/{pilotAbilityId}", async (int pilotAbilityId) =>
{
    PilotAbility pilotAbilityToRetun = await PilotAbilityRepository.GetPilotAbilityByIdAsync(pilotAbilityId);

    if (pilotAbilityToRetun != null)
    {
        return Results.Ok(pilotAbilityToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Pilot Ability Endpoints");


app.MapGet("/getPilotAbilitiesByRobot/{pilotId}", async (int pilotId) =>
{
    var pilotAbilityList = await PilotAbilityRepository.GetPilotAbilitiesByPilotIdAsync(pilotId);

    if (pilotAbilityList != null)
    {
        return Results.Ok(pilotAbilityList);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Pilot Ability Endpoints");

//================================================Robot Card section
app.MapGet("/getAllRobotCards", async () => await RobotCardRepository.GetRobotCardsAsync())
    .WithTags("Robot Card Endpoints");

app.MapGet("/getRobotCardById/{robotCardId}", async (int robotCardId) =>
{
    RobotCard robotCardToRetun = await RobotCardRepository.GetRobotCardByIdAsync(robotCardId);

    if (robotCardToRetun != null)
    {
        return Results.Ok(robotCardToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Robot Card Endpoints");


app.MapGet("/getRobotCardsByRobot/{robotId}", async (int robotId) =>
{
    var robotCardList = await RobotCardRepository.GetRobotCardsByRobotIdAsync(robotId);

    if (robotCardList != null)
    {
        return Results.Ok(robotCardList);
    }
    else 
    {
        return Results.BadRequest();
    }
}).WithTags("Robot Card Endpoints");


//================================================Pilot Card section
app.MapGet("/getAllPilotCards", async () => await PilotCardRepository.GetPilotCardsAsync())
    .WithTags("Pilot Card Endpoints");

app.MapGet("/getPilotCardById/{pilotCardId}", async (int pilotCardId) =>
{
    PilotCard pilotCardToRetun = await PilotCardRepository.GetPilotCardByIdAsync(pilotCardId);

    if (pilotCardToRetun != null)
    {
        return Results.Ok(pilotCardToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Pilot Card Endpoints");


app.MapGet("/getPilotCardsByPilot/{pilotId}", async (int pilotId) =>
{
    var pilotCardList = await PilotCardRepository.GetPilotCardsByPilotIdAsync(pilotId);

    if (pilotCardList != null)
    {
        return Results.Ok(pilotCardList);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Pilot Card Endpoints");

//================================================Builds section
app.MapGet("/getAllBuilds", async () => await BuildRepository.GetBuildsAsync())
    .WithTags("Build Endpoints");

app.MapGet("/getBuildById/{buildId}", async (int buildId) =>
{
    Build buildToRetun = await BuildRepository.GetBuildByIdAsync(buildId);

    if (buildToRetun != null)
    {
        return Results.Ok(buildToRetun);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Build Endpoints");


app.MapGet("/getBuildsByUser/{user}", async (string user) =>
{
    var buildList = await BuildRepository.GetBuildByUserAsync(user);

    if (buildList != null)
    {
        return Results.Ok(buildList);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Build Endpoints");


app.MapPost("/createBuild", async (Build userSubmitBuild) =>
{
    bool createSuccessful = await BuildRepository.CreateBuildAsync(userSubmitBuild);

    if (createSuccessful)
    {
        return Results.Ok("Created Build successfully");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Build Endpoints");

app.MapPut("/updateBuild", async (Build updateBuild) =>
{
    bool createSuccessful = await BuildRepository.UpdateBuildAsync(updateBuild);

    if (createSuccessful)
    {
        return Results.Ok("Updated Build successfully");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Build Endpoints");

app.MapDelete("/deleteBuildById/{BuildId}", async (int buildId) =>
{
    bool deleteSuccessful = await BuildRepository.DeleteBuildAsync(buildId);

    if (deleteSuccessful)
    {
        return Results.Ok("build has been deleted successfully");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Build Endpoints");

app.Run();