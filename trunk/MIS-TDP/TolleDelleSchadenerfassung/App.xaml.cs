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

namespace TolleDelleSchadenerfassung
{
    public partial class App : Application
    {
        /// <summary>
        /// Ermöglicht den einfachen Zugriff auf den Hauptframe der Phone-Anwendung.
        /// </summary>
        /// <returns>Der Hauptframe der Phone-Anwendung</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Konstruktor für das Anwendungsobjekt
        /// </summary>
        public App()
        {
            // Globaler Handler für nicht erfasste Ausnahmen. 
            // Beachten Sie, dass Ausnahmen, die durch das ApplicationBarItem.Click-Objekt verursacht werden, hier nicht erfasst werden.
            UnhandledException += Application_UnhandledException;

            // Profilerstellungsinformationen für Grafiken beim Debuggen anzeigen
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Aktuelle Frameratezähler anzeigen
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Bereiche der Anwendungen anzeigen, die in jedem Frame neu gezeichnet werden
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Visualisierungsmodus für die Nichtproduktionsanalyse aktivieren. 
                // In diesem Modus werden die Bereiche einer Seite, auf die eine GPU-Beschleunigung angewandt wird, mit einer Farbüberlagerung angezeigt.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
            }

            // Silverlight-Standardinitialisierung
            InitializeComponent();

            // Phone-spezifische Initialisierung
            InitializePhoneApplication();
        }

        // Beim Start der Anwendung auszuführender Code
        // Dieser Code wird nicht ausgeführt, wenn die Anwendung reaktiviert wird.
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Bei der Aktivierung der Anwendung auszuführender Code
        // Dieser Code wird nicht beim ersten Start der Anwendung ausgeführt.
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Bei der Deaktivierung der Anwendung auszuführender Code
        // Dieser Code wird nicht beim Schließen der Anwendung ausgeführt.
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Beim Schließen der Anwendung auszuführender Code
        // Dieser Code wird nicht ausgeführt, wenn die Anwendung deaktiviert wird.
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Bei einem Navigationsfehler auszuführender Code
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Fehler bei einer Navigation; Debugger wird unterbrochen.
                System.Diagnostics.Debugger.Break();
            }
        }

        // Bei unbehandelten Ausnahmen auszuführender Code
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Es ist eine unbehandelte Ausnahme aufgetreten; Debugger wird unterbrochen.
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Initialisierung der Phone-Anwendung

        // Vermeiden Sie doppelte Initialisierungen.
        private bool phoneApplicationInitialized = false;

        // Fügen Sie dieser Methode keinen zusätzlichen Code hinzu.
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Erstellen Sie den Frame, aber legen Sie ihn noch nicht als RootVisual-Objekt fest; auf diese Weise
            // bleibt der Begrüßungsbildschirm aktiv, bis die Anwendung zum Rendern bereit ist.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handhabung von Navigationsfehlern
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Stellen Sie sicher, dass keine erneute Initialisierung erfolgt.
            phoneApplicationInitialized = true;
        }

        // Fügen Sie dieser Methode keinen zusätzlichen Code hinzu.
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Legen Sie das RootVisual-Objekt fest, damit die Anwendung gerendert werden kann
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Entfernen Sie diesen Handler, da er nicht mehr benötigt wird.
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}