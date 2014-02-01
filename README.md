# WebMagic

Collection of web specific classes.

## MarkdownPages

MarkdownPages allows you to create a website that will serve markdown pages. Follow these steps:

### Create an Empty ASP.NET Web Application

The steps for Visual Studio 2013 are:

- File
- New
- Project
- Web

### Update Web.config

Add the following settings to Web.config.

    <configuration>
        <appSettings>
            <add key="webPages:Enabled" value="true"/>
            <add key="webPages:Version" value="2.0"/>
        </appSettings>
    </configuration>

Note: webPages:Version value can change depending on your current frameworks.

### _PageStart.cshtml

Add _PageStart.cshtml to the root directory. This file is executed when any page in the website is displayed. This includes markdown pages. The usual contents for this file are:

    @{
        Layout = "_Layout.cshtml";
    }

### _Layout.cshtml

If your _PageStart.cshtml has defined the layout page as above then create a standard ASP.NET layout page. A very basic example:

    <!DOCTYPE html>
    <html>
        <head>
            <title>demo with layout page</title>
        </head>
        <body>
            @RenderBody()
        </body>
    </html>

### Global.asax

Add **MarkdownPages.Start()** to your startup routine. e.g.

    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            MarkdownPages.Start();
        }
   }

### Markdown pages

Final step. Add markdown pages to your website project :-)