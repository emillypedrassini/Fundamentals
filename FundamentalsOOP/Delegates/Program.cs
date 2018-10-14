using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    /*
     * Delegate é um objeto que sabe como chamar um método ou um grupo de métodos
     * É uma referencia/ponteiro para uma função
     * è um ponteiro para um método com mesma assinatura
     */

    class Program
    {
        static void Main(string[] args)
        {
            PhotoProcessor photoProcessor = new PhotoProcessor();
            PhotoFilters filters = new PhotoFilters();

            PhotoProcessor.DelegatePhotoFilterHandler filterHandlerDelegate = filters.ApplyBrightness;
            filterHandlerDelegate += filters.ApplyConstrast;
            filterHandlerDelegate += filters.Resize;
            filterHandlerDelegate += RemoveRedEyerFilter;
            photoProcessor.Process("photo.jpg", filterHandlerDelegate);

            Console.WriteLine();

            Action<Photo> filterHandlerDelegateAction = filters.ApplyBrightness;
            filterHandlerDelegateAction += filters.ApplyConstrast;
            filterHandlerDelegateAction += filters.Resize;
            filterHandlerDelegateAction += RemoveRedEyerFilter;
            photoProcessor.Process2("photo.jpg", filterHandlerDelegateAction);

            Console.WriteLine();

            Func<Photo, string> filterHandlerDelegateFunc = filters.Test;
            photoProcessor.Process3("photo.jpg", filterHandlerDelegateFunc);

            Console.ReadLine();
        }

        static void RemoveRedEyerFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEyer");
        }
    }
}
