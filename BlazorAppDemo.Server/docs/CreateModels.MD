## Create Models

Entities Map to Models. The database communicates with the entities to 
perform CRUD operations. However, once the date is received by the Entity
Framework application, the entity data is mapped to models which handle the
data until it is passed back to the entities to complete CRUD operations.

1. Create a folder called ==Print3dModels== under ==BlazorAppDemo.Shared==

2. Create a new class inside the ==Print3dModels== folder called
==EmailModel.cs==. The naming convention is to use the same name as the
corresponding entity with the word "Model" appended to it.

3. Configure EmailModel.
a. Change the signature from:
<br/>`internal class EmailModel`<br/>to<br/>
`public partial class EmailModel`
b. Add the getters and setters.
c. Remove unnecessary using statements


![Create Project](/img/Models/01EmailModel.png)

4. Create a new class for StatusModel
a. Change the signature from:
<br/>`internal class StatusModel`<br/>to<br/>
`public partial class StatusModel`
b. Add the getters and setters.
c. Remove unnecessary using statements
d. Add the foreign key relationships

![Create Project](/img/Models/02StatusModel.png)