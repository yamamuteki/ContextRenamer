namespace ContextRenamer.Service
{
    using System.IO;
    using System.Text.RegularExpressions;

    public class RenameService
    {
        public virtual void AddCreatedAtPrefix(FileInfo fileInfo)
        {
            string newFileName = fileInfo.CreationTime.ToString("yyyyMMdd_") + fileInfo.Name;
            this.Rename(fileInfo, newFileName);
        }

        public virtual void AddCreatedAtPostfix(FileInfo fileInfo)
        {
            string newFileName = Path.GetFileNameWithoutExtension(fileInfo.Name) +
                fileInfo.CreationTime.ToString("_yyyyMMdd") + fileInfo.Extension;
            this.Rename(fileInfo, newFileName);
        }

        public virtual void AddUpdatedAtPrefix(FileInfo fileInfo)
        {
            string newFileName = fileInfo.LastWriteTime.ToString("yyyyMMdd_") + fileInfo.Name;
            this.Rename(fileInfo, newFileName);
        }

        public virtual void AddUpdatedAtPostfix(FileInfo fileInfo)
        {
            string newFileName = Path.GetFileNameWithoutExtension(fileInfo.Name) +
                fileInfo.LastWriteTime.ToString("_yyyyMMdd") + fileInfo.Extension;
            this.Rename(fileInfo, newFileName);
        }

        public virtual void ReplaceCreatedAtPrefix(FileInfo fileInfo)
        {
            string newFileName = fileInfo.CreationTime.ToString("yyyyMMdd_") + Regex.Replace(fileInfo.Name, @"^\d{8}_", string.Empty);
            this.Rename(fileInfo, newFileName);
        }

        public virtual void Rename(FileInfo fileInfo, string newFileName)
        {
            if (fileInfo.DirectoryName == null)
            {
                return;
            }

            string newFullPath = Path.Combine(fileInfo.DirectoryName, newFileName);
            fileInfo.MoveTo(newFullPath);
        }
    }
}
