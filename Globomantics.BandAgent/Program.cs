using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;

namespace Globomantics.BandAgent
{
    class Program
    {
        private const string DeviceConnectionString = 
            "HostName=ps-jack-demo-hub.azure-devices.net;DeviceId=test002;SharedAccessKey=fIzTThiXBEU+Ah5QtvH81w50z9eCCt3vqg6emUHzc2E=";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Initializing Band Agent...");

            var device = DeviceClient.CreateFromConnectionString(DeviceConnectionString);
            await device.OpenAsync();

            var twinProperties = new TwinCollection();
            twinProperties["connectionType"] = "wi-fi";
            twinProperties["connectionStrength"] = "weak";

            await device.UpdateReportedPropertiesAsync(twinProperties);

            //var count = 1;
            //while (true)
            //{
            //    var telemetry = new Telemetry
            //    {
            //        Message = "Sending complex object...",
            //        StatusCode = count++
            //    };

            //    var telemetryJson = JsonConvert.SerializeObject(telemetry);

            //    var message = new Message(Encoding.ASCII.GetBytes(telemetryJson));
            //    await device.SendEventAsync(message);

            //    Console.WriteLine("Message sent to the cloud!");

            //    Thread.Sleep(2000);
            //}

            Console.WriteLine("Device is connected!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
