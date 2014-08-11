# Installing the Web Deployment Tool #

## Introduction ##

The Microsoft® Web Deployment Tool simplifies the migration, management, and deployment of Internet Information Services (IIS) Web servers, Web applications, and Web sites. Administrators can use command-line scripting with the Web Deployment Tool to synchronize IIS 6.0 and IIS 7 and above servers or to migrate an IIS 6.0 server to IIS 7 or above. The Web Deployment Tool also makes it possible for administrators and delegated users to use IIS Manager to deploy Microsoft® ASP.NET and PHP applications to an IIS 7 and above servers.

With the Web Deployment Tool, you can:


- Migrate Web applications between IIS 6.0 and IIS 7 and above.
Simplify the planning of your IIS 6.0 to IIS 7 and above migrations by determining incompatibilities and previewing the proposed changes before starting the process. Learning about any potential issues in advance gives you the chance to take corrective measures and simplifies migration.

- Synchronize your server farm.
The Web Deployment Tool makes it possible for you to efficiently synchronize sites, applications, or servers across your IIS server farm by detecting differences between the source and destination content and transferring only those changes which need synchronization. The tool simplifies the synchronization process by automatically determining the configuration, content, and certificates to be synchronized for a specific site. In addition to the default behavior, you still have the option to specify additional providers for the synchronization, including databases, Component Object Model (COM) objects, Global Assembly Cache (GAC) assemblies, and registry settings.

- Package, archive, and deploy Web applications.
You can use the Web Deployment Tool to package configuration and content of your installed Web applications, including databases, and use the packages for storage or redeployment. These packages can be deployed using IIS Manager without requiring administrative privileges. The tool integrates with Microsoft® Visual Studio® 2010 to help developers streamline the deployment of Web applications to the Web server. The tool also integrates with the Microsoft® Web Platform Installer (Web PI) so you can simply and easily install community Web applications. You can submit your own application to the Web Application Gallery.

## Download and Install the Web Deployment Tool ##

The Web Deployment Tool is a managed code framework that includes the public application programming interfaces (APIs) and underlying engine. (This is the top-level node and cannot be removed.)

- **IIS Manager UI Module** – UI module makes it possible for users to perform a subset of deployment tasks, mainly packaging or deploying a Web site or app. This module requires the installation of IIS 7 or above, or IIS Remote Manager.
- **Remote Agent Service** – An administrator-only service based on HTTP/HTTPS that allows server administrators to connect and perform remote operations.
- **IIS Deployment Handler** – A handler that integrates with Web Management Service (WMSvc) and allows non-administrators or administrators to perform remote operations. This handler requires the installation of IIS with WMSvc.


### CHOOSE INSTALLATION OPTIONS ###

Before you install the Web Deployment Tool, decide whether you want to use the remote service to perform live operations between two servers or if you prefer to use the offline mode.

- The remote service is not started by default and is set to Manual startup. It is only required to have it running during an operation, and it can be stopped when not in use.
- Offline mode is simply installation of the tool without the service. It requires you to create a local copy of a site or server and then manually copy this “snapshot” or archive to the destination.

Note that you only need the remote service installed on either the source or the destination. For example, to “push” all content from a server to a client, you can install the remote service on all client computers so that the content can be pushed from the source. Alternatively, you could have each client “pull” from the server and only install the remote service on the source.

## HowTo install the tool with a custom remote service URL ##

1. Download the [Web Deployment Tool](http://technet.microsoft.com/en-us/library/dd569059(WS.10).aspx). (HERE: WebDeploy_2_10_amd64_en-US)
2. Install
3. Manually start the service by running the following command:  
   ```net start msdepsvc```

It will install to the default port 8172 and should add a Firewall rule!



----------
(Text from http://www.iis.net/learn/publish/using-web-deploy/use-the-web-deployment-tool )