using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutSystems.ExternalLibraries.SDK;

namespace SFTP_Forge
{
    [OSInterface]
    public interface ISFTP
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        void Get(string IP, int Port, string Username, string Password, string Path, out byte[] Data, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        void Put(string IP, int Port, string Username, string Password, string Path, byte[] Data, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Host">host (IP address or fully qualified hostname)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password">Plain text password.</param>
        /// <param name="Path">default: &quot;/&quot;</param>
        /// <param name="NumberOfFiles">Number of files to fetch. Missing or 0 will return all files.
        /// </param>
        /// <param name="List"></param>
        void List(string Host, int Port, string Username, string Password, string Path, int NumberOfFiles, out List<RemoteItemStructure> List, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Host">host (IP address or fully qualified hostname)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        void Move(string Host, int Port, string Username, string Password, string Source, string Target, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Host">host (IP address or fully qualified hostname)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        void Delete(string Host, int Port, string Username, string Password, string Path, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        void Mkdir(string IP, int Port, string Username, string Password, string Path, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        void Rmdir(string IP, int Port, string Username, string Password, string Path, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        /// <param name="FileName">File name to search</param>
        /// <param name="File"></param>
        void Search(string IP, int Port, string Username, string Password, string Path, string FileName, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Host">host (IP address or fully qualified hostname)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Path"></param>
        /// <param name="Exists"></param>
        void Exists(string Host, int Port, string Username, string Password, string Path, out bool Exists, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="Message">returned error message</param>
        void Delete_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="Exists"></param>
        void Exists_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out bool Exists, out bool Success, out string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        void Get_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, out byte[] Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="NumberOfFiles">Number of files to fetch. Missing or 0 will return all files.</param>
        /// <param name="List"></param>
        void List_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, int NumberOfFiles, out List<RemoteItemStructure> List);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        void Mkdir_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        void Move_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Source, string Target);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="Data"></param>
        void Put_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, byte[] Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        void Rmdir_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">host (e.g. &quot;127.0.0.1&quot;)</param>
        /// <param name="Port">default: 22</param>
        /// <param name="Username"></param>
        /// <param name="PrivateKey">.pem file content</param>
        /// <param name="Path"></param>
        /// <param name="FileName">File name to search</param>
        /// <param name="File"></param>
        void Search_PrivateKey(string IP, int Port, string Username, byte[] PrivateKey, string Path, string FileName, out RemoteItemStructure File);


    }
}
