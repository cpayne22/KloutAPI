using System;
using System.Drawing;
using KloutAPI;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace JsonExample
{
    public partial class JsonExampleViewController : UIViewController
    {
        public JsonExampleViewController() : base ("JsonExampleViewController", null)
        {
        }
		
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }
		
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            KloutAPI.KloutAPI klout = new KloutAPI.KloutAPI("7jeqmvvev9e87bkemy9we8d6", "pierceboggan");
            KloutIdentityResponse response = klout.GetKloutIdentity();
            KloutScoreResponse score = klout.GetKloutScore();
            var alert = new UIAlertView("Score", score.score, null, "Okay", null);
            alert.Show();
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}

