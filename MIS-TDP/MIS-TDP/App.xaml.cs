﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MIS_TDP.Controller;
using System.Diagnostics;

namespace MIS_TDP
{
    public partial class App : Application
    {
        /// <summary>
        /// Bietet einen einfachen Zugriff auf den Stammframe der Phone-Anwendung.
        /// </summary>
        /// <returns>Der Stammframe der Phone-Anwendung.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        private DatabaseController databaseController;

        /// <summary>
        /// Konstruktor für das Application-Objekt.
        /// </summary>
        public App()
        {
            databaseController = DatabaseController.Instance;
            DatabaseContext db = new DatabaseContext(DatabaseContext.ConnectionString);

            if (!db.DatabaseExists())
            {
                databaseController.CreateDatabase();
                //Stammdaten anlegen
                this.createMasterData();

                //Testdaten anlegen
                this.createDummies();
            }

            /**
            // Klassen instanzieren
            MainWindowViewModel mwvm = new MainWindowViewModel();
            **/

            // Globaler Handler für nicht abgefangene Ausnahmen. 
            UnhandledException += Application_UnhandledException;

            // Silverlight-Standardinitialisierung
            InitializeComponent();

            // Phone-spezifische Initialisierung
            InitializePhoneApplication();

            // Während des Debuggens Profilerstellungsinformationen zur Grafikleistung anzeigen.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Zähler für die aktuelle Bildrate anzeigen.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Bereiche der Anwendung hervorheben, die mit jedem Bild neu gezeichnet werden.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Nicht produktiven Visualisierungsmodus für die Analyse aktivieren, 
                // in dem Bereiche einer Seite angezeigt werden, die mit einer Farbüberlagerung an die GPU übergeben wurden.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Deaktivieren Sie die Leerlauferkennung der Anwendung, indem Sie die UserIdleDetectionMode-Eigenschaft des
                // PhoneApplicationService-Objekts der Anwendung auf "Disabled" festlegen.
                // Vorsicht: Nur im Debugmodus verwenden. Eine Anwendung mit deaktivierter Benutzerleerlauferkennung wird weiterhin ausgeführt
                // und verbraucht auch dann Akkuenergie, wenn der Benutzer das Handy nicht verwendet.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code, der beim Starten der Anwendung ausgeführt werden soll (z. B. über "Start")
        // Dieser Code wird beim Reaktivieren der Anwendung nicht ausgeführt
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {

        }

        // Code, der ausgeführt werden soll, wenn die Anwendung aktiviert wird (in den Vordergrund gebracht wird)
        // Dieser Code wird beim ersten Starten der Anwendung nicht ausgeführt
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code, der ausgeführt werden soll, wenn die Anwendung deaktiviert wird (in den Hintergrund gebracht wird)
        // Dieser Code wird beim Schließen der Anwendung nicht ausgeführt
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code, der beim Schließen der Anwendung ausgeführt wird (z. B. wenn der Benutzer auf "Zurück" klickt)
        // Dieser Code wird beim Deaktivieren der Anwendung nicht ausgeführt
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code, der bei einem Navigationsfehler ausgeführt wird
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Navigationsfehler. Unterbrechen und Debugger öffnen
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code, der bei nicht behandelten Ausnahmen ausgeführt wird
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Eine nicht behandelte Ausnahme ist aufgetreten. Unterbrechen und Debugger öffnen
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Initialisierung der Phone-Anwendung

        // Doppelte Initialisierung vermeiden
        private bool phoneApplicationInitialized = false;

        // Fügen Sie keinen zusätzlichen Code zu dieser Methode hinzu
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Frame erstellen, aber noch nicht als RootVisual festlegen. Dadurch kann der Begrüßungsbildschirm
            // aktiv bleiben, bis die Anwendung bereit für das Rendern ist.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Navigationsfehler behandeln
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Sicherstellen, dass keine erneute Initialisierung erfolgt
            phoneApplicationInitialized = true;
        }

        // Fügen Sie keinen zusätzlichen Code zu dieser Methode hinzu
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Visuelle Stammkomponente festlegen, sodass die Anwendung gerendert werden kann
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Dieser Handler wird nicht mehr benötigt und kann entfernt werden
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion


        List<TblFabrikat> fabrikate;
        List<TblVersicherung> versicherungen;
        private void createMasterData()
        {
            TblFabrikat fab;
            TblVersicherung ver;

            this.fabrikate = new List<TblFabrikat>();
            this.versicherungen = new List<TblVersicherung>();


            fab = new TblFabrikat();
            fab.Bezeichnung = "Mercedes";
            fabrikate.Add(fab);

            fab = new TblFabrikat();
            fab.Bezeichnung = "Porsche";
            fabrikate.Add(fab);

            fab = new TblFabrikat();
            fab.Bezeichnung = "Volkswagen";
            fabrikate.Add(fab);

            fab = new TblFabrikat();
            fab.Bezeichnung = "Audi";
            fabrikate.Add(fab);

            fab = new TblFabrikat();
            fab.Bezeichnung = "Opel";
            fabrikate.Add(fab);

            fab = new TblFabrikat();
            fab.Bezeichnung = "BMW";
            fabrikate.Add(fab);

            ver = new TblVersicherung();
            ver.Name = "Aachen Münchener";
            versicherungen.Add(ver);

            ver = new TblVersicherung();
            ver.Name = "HUK";
            versicherungen.Add(ver);

            ver = new TblVersicherung();
            ver.Name = "Allianz";
            versicherungen.Add(ver);

            ver = new TblVersicherung();
            ver.Name = "Provinzial";
            versicherungen.Add(ver);


            foreach (TblFabrikat f in this.fabrikate)
                databaseController.AddFabrikat(f);

            foreach (TblVersicherung v in this.versicherungen)
                databaseController.AddVersicherung(v);

        }

        private void createDummies()
        {
            TblAuftrag test = new TblAuftrag();
            test.GeschaetzterSchaden = 500;
            test.KfzKennzeichen = "AC-HP 1";
            test.VersicherterVorname = "Heinz";
            test.VersicherterName = "Peter";
            test.KfzFabrikatNr = this.fabrikate[0].ID;
            test.VersicherungNr = this.versicherungen[0].VersicherungNr;
            databaseController.AddAuftrag(test);

            TblAuftrag test1 = new TblAuftrag();
            test1.GeschaetzterSchaden = 700;
            test1.KfzKennzeichen = "AC-MM 1";
            test1.VersicherterVorname = "Max";
            test1.VersicherterName = "Mustermann";
            test1.KfzFabrikatNr = this.fabrikate[1].ID;// databaseController.GetFabrikat(this.fabrikate[1].ID);
            test1.VersicherungNr = this.versicherungen[1].VersicherungNr;
            databaseController.AddAuftrag(test1);
        }
    }
}