//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Packaging;
    
    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void InitializeContainer()
        {
            var catalog = new AggregateCatalog();
            var packageCatalog = new PackageCatalog();
            catalog.Catalogs.Add(packageCatalog);
            packageCatalog.AddPackage(Package.Current);
            var container = new CompositionContainer(catalog);
            container.ComposeExportedValue(packageCatalog);
            CompositionHost.InitializeContainer(container);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitializeContainer();
            RootVisual = new Shell();
           /*
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            var container = new CompositionContainer(catalog);
            var cb = new CompositionBatch();
            cb.AddExportedValue(container);
            cb.AddExportedValue("AssemblyComponentCatalog", catalog);
            container.Compose(cb);

            try
            {
                var rootPage = container.GetExportedValue<Shell>("RootPage");
                this.RootVisual = rootPage;
            }
            catch (CompositionException ex)
            {
                this.RootVisual = new ErrorWindow(ex.Errors);
            }
             */
           
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;

                try
                {
                    string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                    errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                    System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
