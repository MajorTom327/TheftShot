using System;
using System.IO;

namespace TheftShot
{
    class TSService
    {
        private string _filePath = Path.Combine(TSConstants.BaseDir, "sessions.txt");
        public TSCamera camera;
        public TSService() {
            
        }
        public void Start() {
            this.camera = new TSCamera();
            Console.WriteLine("TheftShotService created");

            using (var f = System.IO.File.AppendText(_filePath))
            {
                f.WriteLine($"Session start: {DateTime.Now.ToString("s")}");
            }
            this.camera.TakePicture();
        }
        public void Stop() {
            using (var f = System.IO.File.AppendText(_filePath))
            {
                f.WriteLine($"Session close: {DateTime.Now.ToString("s")}");
            }
        }
    }
}
