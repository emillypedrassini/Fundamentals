using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class PhotoProcessor
    {
        public delegate void DelegatePhotoFilterHandler(Photo photo);


        public void Process(string path, DelegatePhotoFilterHandler delegateFilterHandler)
        {
            var photo = Photo.Load(path);

            delegateFilterHandler(photo);

            photo.Save();
        }

        public void Process2(string path, Action<Photo> delegateFilterHandler)
        {
            var photo = Photo.Load(path);

            delegateFilterHandler(photo);

            photo.Save();
        }

        public void Process3(string path, Func<Photo, string> delegateFilterHandler)
        {
            var photo = Photo.Load(path);

            var result = delegateFilterHandler(photo);
            Console.WriteLine(result);

            photo.Save();
        }
    }
}
