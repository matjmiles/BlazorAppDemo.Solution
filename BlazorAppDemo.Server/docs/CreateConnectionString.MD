### [[Back to Index]](Index.MD)

## Configuring a SQL connection in Entity Framework

 
1. Once you have created the DbContext, you create a SQL connection string. Below is an example for a local SQLEXPRESS database and a remote 
SQL database.

### Local Database
`
"Print3dConnection": "Data Source=21MILESM\\SQLEXPRESS;Initial Catalog=Print3D; TrustServerCertificate=True; User Id=print3d; Password=test123$"
`

### Remote Database
`
"Print3dConnection": "Data Source=somedbserver.byui.edu;Initial Catalog=theSQLDB; TrustServerCertificate=True; Integrated Security=True"
`

---
 The connection string is placed in the **appsettings.json.Development** file during development, 
 then moved to **appseetings.json** for production. Below is an example **appsettings.json.Development** file:

 ```
 {
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Print3dConnectionNew": "Data Source=SomeDBServer;Initial Catalog=theSQLDB; TrustServerCertificate=True; Integrated Security=True"

  }
  ```
}

2. Now that both the DbContext and Connection String have been created, we must
reference both in the Program.cs file