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
    class TSCamera
    {
        static FilterInfoCollection DevicesCollection;
        static VideoCaptureDevice Device;
        static NewFrameEventHandler _frameEventHandler;
        public TSCamera()
        {
            Console.WriteLine("Camera Created");
            GetCameraList();
            _frameEventHandler = new NewFrameEventHandler(Device_NewFrame);
        }


        public void GetCameraList()
        {
            if (DevicesCollection == null)
                DevicesCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (Device == null)
                Device = new VideoCaptureDevice(DevicesCollection[0].MonikerString);
        }

        public void TakePicture()
        {
            if (Device == null)
                GetCameraList();
            
            Device.Start();
            Device.NewFrame += _frameEventHandler;
        }

        static void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Image img = (Bitmap)eventArgs.Frame.Clone();

            string fileName = "Capture_" + DateTime.Now.ToString("s", DateTimeFormatInfo.InvariantInfo);
            fileName = fileName
                .Replace(" ", "_")
                .Replace(":", "_")
                .Replace("-", "_") + ".jpg";
            
            var combinedPath = Path.Combine(TSConstants.BaseDir, fileName);
            img.Save(combinedPath);

            Device.SignalToStop();
            Device.NewFrame -= _frameEventHandler;
            Console.WriteLine($"Capture was saved {combinedPath}");
        }
    }
}
