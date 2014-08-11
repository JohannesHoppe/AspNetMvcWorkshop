# Configure the Web Deployment Handler #


his guide provides a basic overview of the steps to configure the Web Deployment handler on your hosted server and test that a user can deploy applications to a Web site. This setup will be using the information in this document to install the Web Deployment Tool onto a new server and configure recommended settings.

## PREREQUISITES ##

This guide requires the following prerequisites:

* .NET Framework 2.0 SP1 or greater
* Web Deployment Tool 1.0 or 1.1
* IIS 7 or above with the Web Management Service (WMSvc) installed

Note: If you have not already installed the Web Deployment Tool, see [Installing the Web Deployment Tool](InstallingTheWebDeploymentTool).

## CONFIGURE WMSVC AND IIS MANAGER PERMISSIONS ##

Install IIS and the Web Management Service on your Windows Server 2008 server.

Configure WMSVC so that remote connections are allowed.

1. Open IIS Manager.
2. Select the Server node.
3. In **Features View** of the Server, double-click the **Management Service** icon.
4. Ensure that the **Enable remote connections** checkbox is selected. If the checkbox is not selected and grayed out, use the **Actions** pane to stop the WMSvc Service. This will let you select the checkbox.
5. On the right-hand **Actions** pane, click **Start**. The **Enable remote connections** checkbox will be selected and grayed out.

Enable admin-only synchronization (bad security, but easy!) 

1. Go to the Management Service Delegation page.
2. In the Actions pane, click Edit Feature Settings, and
3. then select Allow administrators to bypass rules.

----------------------------------------------
(copy from http://www.iis.net/learn/publish/using-web-deploy/configure-the-web-deployment-handler which is down)