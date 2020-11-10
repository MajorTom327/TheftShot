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

            System.IO.File.WriteAllText(_filePath, $"Session start: {DateTime.Now.ToString("s")}");
            this.camera.TakePicture();
        }
        public void Stop() {
            System.IO.File.WriteAllText(_filePath, $"Session start: {DateTime.Now.ToString("s")}");
        }
    }
}
