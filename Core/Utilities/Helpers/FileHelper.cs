using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {

        public static string folderName = @"C:\Users\arif\source\repos\ReCapProject\Images\Araç Resimleri";
        public static string Add(int Id, IFormFile file)
        {

            var sourcepath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                // Ana Klasör

                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }

                // Alt Klasör Oluşturma

                string subName = folderName + "\\" + Id;

                if (!Directory.Exists(subName))
                {
                    Directory.CreateDirectory(subName);
                }

                // Uzantıyı Alma

                FileInfo ff = new FileInfo(file.FileName);
                string fileExtension = ff.Extension;

                string imgName = "Car " + Id + " - " + Guid.NewGuid() + fileExtension;

                //using (FileStream filestream = File.Create(imgName))
                using (var filestream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                    filestream.Flush();
                }

                var result = newPath(file,Id);
                File.Move(sourcepath, result);
                return result;
            }

            return null;
        }

        public static string newPath(IFormFile file, int Id)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var imgName = "Car " + Id + " - " + Guid.NewGuid() + fileExtension;

            string subName = folderName + "\\" + Id;

            string result = $"{subName}\\{imgName}";
            return result;
        }


        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string sourcePath, IFormFile file, int Id)
        {
            var result = newPath(file,Id);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

    }
}











//-------------------------------------------------2. ÖRNEK--------------------------------------
//public static string Add(IFormFile file)
//{
//    var sourcepath = Path.GetTempFileName();            

//    if (file.Length > 0)
//    {
//        using (var stream = new FileStream(sourcepath, FileMode.Create))
//        {
//            file.CopyTo(stream);
//        }
//    }
//    var result = newPath(file);
//    File.Move(sourcepath, result);
//    return result;

//    //var sourcepath = Path.GetTempFileName();
//    //if (file.Length > 0)
//    //{
//    //    using (var stream = new FileStream(sourcepath, FileMode.Create))
//    //    {
//    //        file.CopyTo(stream);
//    //    }
//    //}
//    //var result = newPath(file);
//    //File.Move(sourcepath, result);
//    //return result;
//}

//public static void Delete(string path)
//{
//    File.Delete(path);
//}


//public static string Update(string sourcePath, IFormFile file)
//{
//    var result = newPath(file);

//    if (sourcePath.Length > 0)
//    {
//        using (var stream = new FileStream(result, FileMode.Create))
//        {
//            file.CopyTo(stream);
//        }
//    }
//    File.Delete(sourcePath);
//    return result;
//}


//public static string newPath(IFormFile file)
//{
//    FileInfo ff = new FileInfo(file.FileName);
//    string fileExtension = ff.Extension;
//    var newPath = "Images\\" + Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
//    string result = $@"{newPath}";
//    return result;
//}



//----------------------------------------------1. ÖRNEK-------------------------------------
//public static string Add(IFormFile file)
//{
//    //gönderilen resmin tüm yolunu (path) getirir:

//    var sourcepath = Path.GetTempFileName();

//    if (file.Length > 0)
//    {
//        //eklenen resim boş ise, resmin bulunduğu yerde yeni bir dosya oluşturur.dosyaya resmi kaydeder.
//        using (var stream = new FileStream(sourcepath, FileMode.Create))
//        {
//            file.CopyTo(stream);
//        }
//    }
//    var result = newPath(file);

//    // resmi kaynak dosyadan, yeni oluşturulan path'e taşır:

//    File.Move(sourcepath, result);
//    return result;
//}
//public static IResult Delete(string path)
//{
//    try
//    {
//        File.Delete(path);
//        return new SuccessResult();
//    }
//    catch (Exception exception)
//    {
//        return new ErrorResult(exception.Message);
//    }


//}
//public static string Update(string sourcePath, IFormFile file)
//{
//    var result = newPath(file);

//    if (sourcePath.Length > 0)
//    {
//        using (var stream = new FileStream(result, FileMode.Create))
//        {
//            file.CopyTo(stream);
//        }
//    }
//    File.Delete(sourcePath);
//    return result;
//}

//// yüklenen resme yeni bir dosya yolu yazan mehthod:

//public static string newPath(IFormFile file)
//{
//    //Yüklediğimiz resmin ismini alır.

//    FileInfo ff = new FileInfo(file.FileName);

//    //Yüklediğimiz resmin uzantısını alır: .jpeg, .png vs.
//    string fileExtension = ff.Extension;

//    //Geçerli çalışma dizininin tam yolunu get-set eder:
//    string path = Environment.CurrentDirectory + @"\wwwroot\Images";

//    //Benzersiz bir path oluşturur:
//    var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

//    //String ifadedeki /,: boşluk gib ifadeleri - 'ye çevirir:
//    string unique = Regex.Replace(newPath, "[/|:| ]", "-");

//    //benzersiz path artık hazır:
//    string result = $@"{path}\{unique}";

//    return result;
//}

