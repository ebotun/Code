using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System;
using System.Text;
using System.IO;
using System.Threading;
using Java.Lang;
using Android.Content;
using Android.Provider;
using Android.Graphics;

namespace MobilePython
{
    [Activity(Label = "MobilePython", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static TextView txt;
        public static TextView txtInput;
        public static ImageView image;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button btn = FindViewById<Button>(Resource.Id.btn);
            txt = FindViewById<TextView>(Resource.Id.txt1);
            txtInput = FindViewById<TextView>(Resource.Id.txtinput);
            btn.Click += GetData;
            var btnCamera = FindViewById<Button>(Resource.Id.btnCamera);
            image = FindViewById<ImageView>(Resource.Id.camera);
            btnCamera.Click += BtnCamera_Click;

        }
        public async void GetData(object sender, EventArgs e)
        {
            txt.Text = "Loading Data...";
            await Task.Run(() =>
            {
                RunOnUiThread(() => {
                    WebClient wc = new WebClient();
                    try
                    {
                        using (Stream st = wc.OpenRead($"http://10.0.2.2:80/?Name={txtInput.Text}"))
                        {
                            using (StreamReader sr = new StreamReader(st, Encoding.UTF8))
                            {
                                string html = sr.ReadToEnd();
                                txt.Text = html;
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        txt.Text = "Failed to connect";
                    }
                    
                    
                });
            });

            



        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            image.SetImageBitmap(bitmap);
        }
        public void BtnCamera_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);

        }
        
    }
}