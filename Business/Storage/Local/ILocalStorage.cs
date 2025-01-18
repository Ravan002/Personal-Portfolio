using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Storage.Local
{
    public interface ILocalStorage
    {
        Task<string> AddImage(IFormFile file, string projectName, string folderName);
        bool DeleteImage(string folderName, string imageWithProjectName);
    }
}
