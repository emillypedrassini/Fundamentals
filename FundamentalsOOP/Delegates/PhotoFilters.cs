using System;

namespace Delegates
{
    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyConstrast(Photo photo)
        {

            Console.WriteLine("Apply Constrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");
        }

        public string Test(Photo photo)
        {
            Console.WriteLine("Test");
            return "Test";
        }
    }
}
