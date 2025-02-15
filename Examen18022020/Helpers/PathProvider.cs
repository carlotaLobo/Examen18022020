﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Helpers
{
    public enum Folders { 
        Images = 0, Documents = 1, Temporal = 2
    }

    public class PathProvider
    {
        IWebHostEnvironment environment;
        
        public PathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public String MapPath(String filename, Folders folder)
        {
            String carpeta = "";
            if (folder == Folders.Documents)
            {
                carpeta = "documents";
            }else if (folder == Folders.Images)
            {
                carpeta = "images";
            }else if (folder == Folders.Temporal)
            {
                carpeta = "temporal";
            }
            String path = Path.Combine(this.environment.WebRootPath
                , carpeta, filename);
            //c:\\server\\wwwroot\\1.xml
            //c:\server\wwwroot\1.xml
            return path;
        }
    }
}
