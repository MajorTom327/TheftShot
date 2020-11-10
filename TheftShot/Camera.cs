using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Globalization;

namespace TheftShot
{
    class Camera
    {
        static FilterInfoCollection DevicesCollection;
        static VideoCaptureDevice Device;
        private const string BaseDir = @"C:\Temp\TheftShot\";
        public Camera()
        {
            if (Device == null)
                GetCameraList();
        }

        public void CreateStockageDir()
        {

            (new FileInfo(BaseDir)).Directory.Create();
        }

        public void GetCameraList()
        {
            DevicesCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Device = new VideoCaptureDevice(DevicesCollection[0].MonikerString);
            Device.Start();
            Device.NewFrame += new NewFrameEventHandler(Device_NewFrame);
        }

        static void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Image img = (Bitmap)eventArgs.Frame.Clone();
            string fileName = "Image" + DateTime.Now.ToString("s", DateTimeFormatInfo.InvariantInfo);
            fileName = fileName.Replace(" ", "_").Replace(":","_");
            fileName = fileName + ".jpg";
            var combinedPath = Path.Combine(BaseDir, fileName);
            img.Save(combinedPath);
            Device.SignalToStop();
        }

    }
}
