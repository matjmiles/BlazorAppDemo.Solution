## Creating a Map between Entities and Models

Entities represent tables in your SQL database. When your application requests or sends
data from the database, that data passes through entities. However, once the data is received
by your application corresponding Models are populated from those entities. Any data manipulation
that happens in the application deals with the Models. The models then send the updated data
back to the entities, and the data in the entities is committed to the database during CRUD
operations. To create a data map, follow the steps below.


1. Register the ==MappingProfile== in Program.cs under: <br/>
**var builder = WebApplication.CreateBuilder(args);**
```
builder.Services.AddAutoMapper(typeof(MappingProfile));
```

1. Right click on the ==BlazorAppDemo.Infrastructre== Class library > Add > Class <br/>
Name the new class "MappingProfile.cs

2. Right click on the new ==Repositories== folder > Add > Class <br/>
Name the Class "Print3dRepository.cs"

3. Add the following using statements to the top of the file
```
using AutoMapper;
using BlazorAppDemo.Core.Entities;
using BlazorAppDemo.Shared.Print3dModels;
```

4. Change `public class MappingProfile` to `public class MappingProfile : Profile`

5. Inside this class, create your mapping profile as show below.

```
public MappingProfile()
{
    CreateMap<Email, EmailModel>().ReverseMap();
    CreateMap<Status, StatusModel>().ReverseMap();           

}
```

6. The completed class is shown below.
```
using AutoMapper;
using Library.Core.Entities.Print3D;
using Library.Shared.Print3dModels;

namespace Library.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Color, ColorModel>().ReverseMap();
            CreateMap<Coupon, CouponModel>().ReverseMap();
            CreateMap<Email, EmailModel>().ReverseMap();
            CreateMap<Filament, FilamentModel>().ReverseMap();
            CreateMap<Job, JobModel>().ReverseMap();
            CreateMap<Machine, MachineModel>().ReverseMap();
            CreateMap<Printer, PrinterModel>().ReverseMap();
            CreateMap<Status, StatusModel>().ReverseMap();           

        }

    }
}
```
7. Lastly, add the reference to the Mapping Profile in ==Program.cs==

![Create Project](/img/Mapping/01AddMapProfileToProgamCS.png)

`







