namespace PulseProbe.utility
{
    public interface IImage
    {
        void DecodeBase64String(string encodedString, string FolderName, string FirstName, string LastName);
        string encodeToBase64(string FirstName, string LastName, string FolderName);
    }
    public class Image:IImage
    {
        public void DecodeBase64String(string encodedString, string FolderName, string FirstName, string LastName)
        {
            string FileName = FirstName + LastName + ".jpg";
            byte[] decodedBytes = Convert.FromBase64String(encodedString);

            var path = Path.Combine(Directory.GetCurrentDirectory(), FolderName,FileName);
            System.IO.File.WriteAllBytes(path, decodedBytes);
            
        }
        public string encodeToBase64(string FirstName, string LastName, string FolderName)
        {
            var fileName = FirstName + LastName + ".jpg";
            string encodedImage = "";
            var path = Path.Combine(Directory.GetCurrentDirectory(), FolderName, fileName);
            byte[] filebytes = System.IO.File.ReadAllBytes(path);
            encodedImage = Convert.ToBase64String(filebytes);
            return encodedImage;
        }
    }
}
