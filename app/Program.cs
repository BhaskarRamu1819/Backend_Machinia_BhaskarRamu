using Amazon.Runtime.Internal;
using app.configs;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<mongoConnection>(builder.Configuration.GetSection("MongoAfDbSettings"));
builder.Services.AddSingleton<mongoOperations>();
var app = builder.Build();

app.MapGet("/", () => "API get called");

app.MapGet("/trainingcenters", async (mongoOperations mongooperations) => await mongooperations.Get());

app.MapGet("/trainingcenters/{CenterCode}", async (mongoOperations mongooperations, string CenterCode) =>
{
    var eachDoc = await mongooperations.Get(CenterCode);
    var emptyList = new List<string>();
    return eachDoc is null ? Results.NotFound(emptyList) : Results.Ok(eachDoc);
});


var regex = new Regex(@"^\d+$");

app.MapPost("/addnewcenter", async (HttpRequest request, mongoOperations mongooperations, dataAssign dataassign) =>
{
    var eachDoc = await mongooperations.Get(dataassign.CenterCode); //To check CenterCode data available in db
    var validMail = mongooperations.ValidateEmail(dataassign.ContactEmail); //validate the email structure
    //var validateAddress = mongooperations.getAddress(dataassign.Address);
    

    if (eachDoc != null) //if CenterCode data already present sending message
    {
        var error = $"Center code {eachDoc.CenterCode} traing center data already available.";
        return Results.BadRequest(error);
    }
    else if (dataassign.CenterName.Length > 40) //CenterName check lessthan 40 characters
    {
        var error = "Center name should not exceed 40 characters.";
        return Results.BadRequest(error);
    }
    else if (dataassign.CenterCode.Length != 12) //CenterCode check exaxt 12 characters
    {
        var error = "Center code should be 12 characters.";
        return Results.BadRequest(error);
    }
    else if (!regex.IsMatch(dataassign.ContactPhone)) //validate the phone number digits
    {
        var number = dataassign.ContactPhone;
        var error = $"Contact number is not valid - {number}";
        return Results.BadRequest(error);
    }
    else if (!validMail) // validate email
    {
        var error = $"Email is not valid - {dataassign.ContactEmail}";
        return Results.BadRequest(error);
    }
    else //Insert the data by Create method
    {
        await mongooperations.Create(dataassign);
        return Results.Ok(dataassign);
    }
    /*await mongooperations.Create(dataassign);
    return Results.Ok(dataassign);*/
});

app.Run();
