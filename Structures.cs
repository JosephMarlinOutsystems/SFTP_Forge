using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutSystems.ExternalLibraries.SDK;

namespace SFTP_Forge
{
    [OSStructure]
    public struct RemoteItemStructure
    {
        public string Filename;

        public int SizeInBytes;

        public bool IsDir;

        public bool IsLink;

        public DateTime Created;

        public DateTime Modified;

        public RemoteItemStructure(params string[] dummy)
        {
            Filename = "";
            SizeInBytes = 0;
            IsDir = false;
            IsLink = false;
            Created = new DateTime(1900, 1, 1, 0, 0, 0);
            Modified = new DateTime(1900, 1, 1, 0, 0, 0);
        }

    }
}
