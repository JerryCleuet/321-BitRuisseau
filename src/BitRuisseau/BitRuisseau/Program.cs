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
            List<MediaCenter> _remoteMediaCenters = new List<MediaCenter>();    // Création d'une liste factice pour juste afficher la page au début
            Application.Run(new RemoteMediaCentersForm(_remoteMediaCenters));
        }
    }
}