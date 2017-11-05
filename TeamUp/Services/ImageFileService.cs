using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TeamUp.Services
{
    
    public class ImageFileService
    {

        public static void StoreFile(ImageType type, HttpPostedFileBase file, int ownerId)
        {
            file.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserInputedFiles", type.ToString(), ownerId.ToString() + ".jpg"));
        }
        
    }
}