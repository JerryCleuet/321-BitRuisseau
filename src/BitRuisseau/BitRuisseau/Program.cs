using BitRuisseau.Protocol;
using System;
using BitRuisseau.Protocol;

namespace BitRuisseau
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Start the MQTT communicator and announce presence
            try
            {
                // brokerHost can be adjusted (e.g. "localhost")
                var nodeId = Environment.MachineName ?? Guid.NewGuid().ToString();
                var communicator = new Protocol.SimpleMqttCommunicator("localhost", nodeId);
                communicator.StartAsync();

                var envelope = new Envelope(nodeId, string.Empty, MessageType.I_AM_HERE, "I am here");
                communicator.Send(envelope);
            }
            catch (Exception ex)
            {
                // ignore or log startup communication errors; do not prevent UI from starting
                Console.Error.WriteLine($"Failed to announce presence: {ex.Message}");
            }

            Application.Run(new Form1());
        }
    }
}