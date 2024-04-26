using Maui_Api.DTO;
using Microsoft.AspNetCore.Mvc;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Data

var inspections = new List<Inspection>
{
    new()
    {
        Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
        Name = "Inspection 8401",
        Date = DateTime.Now.AddMinutes(-30),
        Status = InspectionStatus.InProgress,
        Description = "Nothing of note to report for AED Inspection 01.",
        ImageUrl = "https://www.heart.org/-/media/Images/News/2023/January-2023/0117AEDThingstoKnowHamlin_SC.jpg",
        Location = new Location
        {
            Id = Guid.Parse("995B7283-5938-4E6A-8B17-01380984DCFF"),
            LocationType = LocationType.AED,
            Name = "AED #1"
        }
    },
    new()
    {
        Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
        Name = "Inspection 9401",
        Status = InspectionStatus.InProgress,
        Date = DateTime.Now.AddMinutes(-35),
        Description = "Nothing of note to report for First Aid Inspection 01.",
        ImageUrl = "https://m.media-amazon.com/images/I/817vU1ZDWGL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
        Location = new Location
        {
            Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
            LocationType = LocationType.FirstAidKit,
            Name = "First Aid Kit #1"
        }
    },
    new()
    {
        Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
        Name = "Inspection 7801",
        Status = InspectionStatus.Complete,
        Date = DateTime.Now.AddMinutes(-40),
        Description = "Nothing of note to report for FE Inspection 01.",
        ImageUrl = "https://s42814.pcdn.co/wp-content/uploads/2003/12/iStock_507530924-1-scaled-1.jpg.optimal.jpg",
        Location = new Location
        {
            Id = Guid.Parse("16B82AD3-49D2-4E40-BD6C-01FB7F5852DE"),
            LocationType = LocationType.FireExtinguisher,
            Name = "Fire Extinguisher #1"
        }
    },
    new()
    {
        Id = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
        Name = "Inspection 9802",
        Status = InspectionStatus.Complete,
        Date = DateTime.Now.AddMinutes(-45),
        Description = "Nothing of note to report for FE Inspection 02.",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6jJUrx3e9XDHToen3Jyc679LuqwloBHEU1w&s",
        Location = new Location
        {
            Id = Guid.Parse("B44DEF69-5F23-4AD9-9B9F-2BDB10A73D4F"),
            LocationType = LocationType.FireExtinguisher,
            Name = "Fire Extinguisher #2"
        }
    },
    new()
    {
        Id = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
        Name = "Inspection 6401",
        Status = InspectionStatus.Complete,
        Date = DateTime.Now.AddMinutes(-50),
        Description = "Nothing of note to report for Smoke Detector Inspection 01.",
        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7k4nBDGQKqdRRVuL-ODhlIcH6mf-UsXiU8A&s",
        Location = new Location
        {
            Id = Guid.Parse("346B0B2B-05EB-4FBE-916A-9C0C8D474112"),
            LocationType = LocationType.SmokeDetector,
            Name = "Smoke Detector #1"
        }
    },
    new()
    {
        Id = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
        Name = "Inspection 8702",
        Status = InspectionStatus.Cancelled,
        Date = DateTime.Now.AddDays(-1),
        Description = "Nothing of note to report for AED Inspection 02.",
        ImageUrl = "https://www.heart.org/-/media/Images/News/2023/January-2023/0117AEDThingstoKnowHamlin_SC.jpg",
        Location = new Location
        {
            Id = Guid.Parse("995B7283-5938-4E6A-8B17-01380984DCFF"),
            LocationType = LocationType.AED,
            Name = "AED #1"
        }
    },
    new()
    {
        Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
        Name = "Inspection 9001",
        Date = DateTime.Now.AddDays(-1),
        Status = InspectionStatus.InProgress,
        Description = "Nothing of note to report for AED Inspection 01.",
        ImageUrl = "https://www.heart.org/-/media/Images/News/2023/January-2023/0117AEDThingstoKnowHamlin_SC.jpg",
        Location = new Location
        {
            Id = Guid.Parse("995B7283-5938-4E6A-8B17-01380984DCFF"),
            LocationType = LocationType.AED,
            Name = "AED #1"
        }
    }
};

var locations = new List<Location>
{
    new()
    {
        Id = Guid.Parse("995B7283-5938-4E6A-8B17-01380984DCFF"),
        LocationType = LocationType.AED,
        Name = "AED #1"
    },
    new()
    {
        Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
        LocationType = LocationType.FirstAidKit,
        Name = "First Aid Kit #1"
    },
    new()
    {
        Id = Guid.Parse("16B82AD3-49D2-4E40-BD6C-01FB7F5852DE"),
        LocationType = LocationType.FireExtinguisher,
        Name = "Fire Extinguisher #1"
    },
    new()
    {
        Id = Guid.Parse("B44DEF69-5F23-4AD9-9B9F-2BDB10A73D4F"),
        LocationType = LocationType.FireExtinguisher,
        Name = "Fire Extinguisher #2"
    }
    ,
    new()
    {
        Id = Guid.Parse("346B0B2B-05EB-4FBE-916A-9C0C8D474112"),
        LocationType = LocationType.SmokeDetector,
        Name = "Smoke Detector #1"
    }
};

#endregion

#region GET Requests

app.MapGet("/inspections", ()
    => Results.Ok(inspections));

app.MapGet("/locations", ()
    => Results.Ok(locations));

app.MapGet("/inspections/{id}", (Guid id) =>
{
    var @inspection = inspections.Find(e => e.Id == id);
    return @inspection is null
        ? Results.NotFound()
    : Results.Ok(@inspection);
});

#endregion

#region UPDATE Requests

app.MapPost("/inspections", (Inspection @inspection) =>
{
    if (!MiniValidator.TryValidate(@inspection, out var errors))
        return Results.ValidationProblem(errors);

    if (!inspections.All(e => e.Name != @inspection.Name && e.Date != @inspection.Date))
        return Results.BadRequest($"An inspection {@inspection.Name} on {@inspection.Date.ToShortDateString()} already exists.");

    @inspection.Id = Guid.NewGuid();
    inspections.Add(@inspection);
    return Results.Created($"/inspections/{@inspection.Id}", @inspection);
});

app.MapPut("/inspections/{id}", (Guid id, Inspection @inspection) =>
{
    if (!MiniValidator.TryValidate(@inspection, out var errors))
        return Results.ValidationProblem(errors);

    var inspectionToUpdate = inspections.Find(e => e.Id == @inspection.Id);

    if (inspectionToUpdate is null) return Results.NotFound();

    inspectionToUpdate.Name = @inspection.Name;
    inspectionToUpdate.Location = @inspection.Location;
    inspectionToUpdate.Date = @inspection.Date;
    inspectionToUpdate.Description = @inspection.Description;
    inspectionToUpdate.ImageUrl = @inspection.ImageUrl;
    inspectionToUpdate.Status = @inspection.Status;

    return Results.NoContent();
});

app.MapPatch("/inspections/{id}/status", (Guid id, [FromBody] InspectionStatus status) =>
{
    var inspectionToUpdate = inspections.Find(e => e.Id == id);

    if (inspectionToUpdate is null) return Results.NotFound();

    inspectionToUpdate.Status = status;

    return Results.NoContent();
});

app.MapDelete("/inspections/{id}", (Guid id) =>
{
    if (inspections.Find(e => e.Id == id) is not Inspection @inspection)
        return Results.NotFound();

    inspections.Remove(@inspection);
    return Results.NoContent();
});

#endregion

app.Run();
