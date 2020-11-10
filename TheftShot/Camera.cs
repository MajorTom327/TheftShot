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

namespace TheftShot
{
    class Camera
    {
        static FilterInfoCollection DevicesCollection;
        static VideoCaptureDevice Device;
        public Camera()
        {
            GetCameraList();
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
            string fileName = "Image";
            fileName = fileName + ".jpg";
            img.Save(@"C:\Temp\TheftShot" + fileName);
            Device.SignalToStop();
        }

    }
}
