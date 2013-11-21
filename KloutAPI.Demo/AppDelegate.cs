using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace KloutAPI.Demo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		DialogViewController dvc;
		UINavigationController nav;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var root = new RootElement ("Klout example");
			var taskElement = new Section ("");

			// See http://developer.klout.com/apps/mykeys
			KloutAPI k = new KloutAPI ("ENTER YOUR KLOUT API", "christian_pyn");

			try {
				var kloutIdentity = k.GetKloutIdentity ();
				var kloutScore = k.GetKloutScore ();

				taskElement.Add (new EntryElement ("Klout Score", "", kloutScore.score.ToString ()));
				taskElement.Add (new EntryElement ("Klout Identity", "", kloutIdentity.id.ToString ()));

				root.Add (taskElement);
			} catch (NullReferenceException) {
				new UIAlertView ("Klout Error", "Check you have a valid Klout API Key.  See http://developer.klout.com/apps/mykeys", null, "Ok", null).Show ();
				taskElement.Add (new EntryElement ("Klout Error", "", ""));
				taskElement.Add (new EntryElement ("", "", "Check you have a valid Klout API Key"));

				root.Add (taskElement);

			}

			dvc = new DialogViewController (root);
			nav = new UINavigationController (dvc);
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

