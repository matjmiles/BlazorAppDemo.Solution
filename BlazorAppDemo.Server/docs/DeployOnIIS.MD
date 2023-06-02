### [[Back to Index]](Index.MD)

## Deploy Application on IIS

### Publish Your Application in Visual Studio

1. Right click on your App and click "Publish"

![Publish Project](img/DeployIIS/10Publish.png)

2. Select the "Folder" Option.

![Publish Project](img/DeployIIS/11Folder.png)

3. Note the publish output location.

![Publish Project](img/DeployIIS/12PublishLocation.png)

4. Save the publishing profile.

![Publish Project](img/DeployIIS/13ProfileComplete.png)

5. Click on "Show All Settings"

![Publish Project](img/DeployIIS/14ShowAllSettings.png)

6. Match the settings as shown

![Publish Project](img/DeployIIS/15SetSettings.png)

7. Publish the project

![Publish Project](img/DeployIIS/16PublishProj.png)

8. Copy the files from the publish directory to a folder on the IIS Server. 
It must be under **c:\\inetpub\wwwroot**. We will create a new folder called blazorTest


### SETUP IIS SERVER

1. Assuming that IIS is already install, from the Windows start go to Control Panel > 
Programs > Turn Windows features on or off

![Create Entity](img/DeployIIS/01TurnOnFeatures.png)

2. Select "Role Based" and click "Next"

![Create Entity](img/DeployIIS/02RoleBased.png)

3.Select the highlighted server and click "Next"

![Create Entity](img/DeployIIS/03SelectServer.png)

4. Make sure that the Application Development option for your program is installed. If
not click the appropriate box then click the "Install" button

![Create Entity](img/DeployIIS/04DotNetExtensibility.png)

5. Download and Install the appropriate version of the Windows Hosting Bundle.

[Link to Download.NET Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.16-windows-hosting-bundle-installer)

![Create Entity](img/DeployIIS/05DownloadHostingBundel.png)

6. Double click on hosting bundle install.

![Create Entity](img/DeployIIS/06ClickInstall.png)

7.  Agree to terms and click "Install"

![Create Entity](img/DeployIIS/07InstallBundle.png)

8.  Once installation completes click "Close"

![Create Entity](img/DeployIIS/08CompleteInstall.png)

9. Restart IIS

![Create Entity](img/DeployIIS/09RestartIIS.png)

