using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using static System.Net.WebRequestMethods;

namespace SFTP_Forge
{
    public class SFTP : ISFTP
    {
        #region Public Methods
        public void List(string Host, int Port, string Username, string Password, string Path, int NumberOfFiles, 
            out List<RemoteItemStructure> List, out bool Success, out string Message)
        {
            List = new List<RemoteItemStructure>();
            Success = false;
            Message = string.Empty;
            using SftpClient sftp = new (Host, Port, Username, Password);
            try
            {
                sftp.Connect();
                int idx = 0;
                foreach (var file in sftp.ListDirectory(Path))
                {
                    if (idx >= NumberOfFiles && NumberOfFiles > 0)
                        break;

                    var remoteItem = new RemoteItemStructure
                    {
                        Filename = file.Name,
                        SizeInBytes = Long2Int(file.Attributes.Size),
                        IsDir = file.IsDirectory,
                        IsLink = file.IsSymbolicLink,
                        Created = file.LastAccessTime,
                        Modified = file.LastWriteTime
                    };

                    List.Add(remoteItem);

                    idx++;
                }
                Success = true;

            }
            catch
            {
                Message = "Failed to list";
            }
            finally
            {
                sftp.Disconnect();
            }
        }
        public void Put(string IP, int Port, string Username, string Password, string Path, byte[] Data, 
            out bool Success, out string Message)
        {
            Success = false;
            Message= string.Empty;

            // Write to a temp file
            string localFile = System.IO.Path.GetTempFileName();
            FileStream s = new FileStream(localFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(s);
            bw.Write(Data);
            bw.Close();

            // Upload the temp file
            using (SftpClient sftp = new(IP, Port, Username, Password))
            {
                try
                {
                    sftp.Connect();
                    FileStream file = new(localFile, FileMode.Open);
                    sftp.UploadFile(file, Path);  // Optional: canOverride
                    file.Close();
                }
                catch 
                {
                    Message = "Failed to put file";
                }
                finally
                {
                    sftp.Disconnect();
                }
            }

            // Delete the temp file
            System.IO.File.Delete(localFile);
        
        }

        public void Get(string IP, int Port, string Username, string Password, string Path, out byte[] Data, 
            out bool Success, out string Message)
        {
            Data = Array.Empty<byte>();
            string localFile = System.IO.Path.GetTempFileName();
            Success = false;
            Message = string.Empty;

            using SftpClient sftp = new(IP, Port, Username, Password);
            try
            {
                sftp.Connect();
                var file = new FileStream(localFile, FileMode.Create);
                sftp.DownloadFile(Path, file);
                file.Close();
                Success = true;
            }
            catch
            {
                Message = "Get failed";
            }
            finally
            {
                sftp.Disconnect();
            }
        }

        public void Exists(string Host, int Port, string Username, string Password, string Path, out bool Exists, 
            out bool Success, out string Message)
        {
            Exists = false;
            Success = false;
            Message = "";

            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                try
                {
                    sftp.Connect();
                    Exists = sftp.Exists(Path);
                    Success = true;
                }
                catch
                {
                    Message = "Failed to execute Exists";
                }
                finally
                {
                    sftp.Disconnect();
                }
            }
        }
        public void Search(string IP, int Port, string Username, string Password, string Path, string FileName, 
            out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Mkdir(string Host, int Port, string Username, string Password, string Path, out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Move(string Host, int Port, string Username, string Password, string Source, string Target, 
            out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Host, int Port, string Username, string Password, string Path, out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Delete_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Exists_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out bool Exists)
        {
            throw new NotImplementedException();
        }

        public void Get_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out byte[] Data)
        {
            throw new NotImplementedException();
        }

        public void List_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, int NumberOfFiles, out List<RemoteItemStructure> List)
        {
            throw new NotImplementedException();
        }

        public void Mkdir_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path)
        {
            throw new NotImplementedException();
        }

        public void Move_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Source, string Target)
        {
            throw new NotImplementedException();
        }

        public void Put_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, byte[] Data)
        {
            throw new NotImplementedException();
        }

        public void Rmdir(string IP, int Port, string Username, string Password, string Path, out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Rmdir_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path)
        {
            throw new NotImplementedException();
        }

        public void Search_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, string FileName, out RemoteItemStructure File)
        {
            throw new NotImplementedException();
        }

        public void Delete_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        public void Exists_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out bool Exists, out bool Success, out string Message)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods
        private int Long2Int(long v)
        {
            if (v >= int.MaxValue) return int.MaxValue;
            else return Convert.ToInt32(v);
        }

        #endregion
    }
}
