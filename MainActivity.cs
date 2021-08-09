using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System.IO;
using System;

namespace Reading_a_Text_File_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tv1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //sets the TextView
            tv1 = FindViewById<TextView>(Resource.Id.textView1);

            //sets the button
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += onbtnclick;
        }

        void onbtnclick(object sender, EventArgs e)
        {
            string content;
            using (StreamReader sr = new StreamReader(Assets.Open("read_asset.txt")))
            {
                content = sr.ReadToEnd();
            }

            tv1.Text = content;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}