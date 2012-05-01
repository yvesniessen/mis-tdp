using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF_WebService
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region members 
        private ServiceHost HostProxy;
        #endregion

        #region constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region react 2 gui events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // netsh http add urlacl url=http://+:8001/test user=Bastian
            string address = "http://localhost:8001/test";
            HostProxy = new ServiceHost(typeof(Test), new Uri(address));

            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            HostProxy.Description.Behaviors.Add(smb);

            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            try
            {
                HostProxy.Open();
                MessageBox.Show("The service is ready at " + address);
                labelServerStatus.Content = "running";
            }
            catch (AddressAccessDeniedException)
            {
                MessageBox.Show("You need to reserve the address for this service");
                HostProxy = null;
                labelServerStatus.Content = "stop";
            }
            catch (AddressAlreadyInUseException)
            {
                MessageBox.Show("Something else is already using this address");
                HostProxy = null;
                labelServerStatus.Content = "stop";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something bad happened on startup: " + ex.Message);
                HostProxy = null;
                labelServerStatus.Content = "stop";
            }
        }
        #endregion
    }
}
