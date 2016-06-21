namespace ContextRenamer.Service
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    public class OptionService
    {
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        protected RenameService RenameService = new RenameService();

        public virtual void Dispatch(string option, string path)
        {
            var fileInfo = new FileInfo(path);

            switch (option)
            {
                case "/c":
                    this.RenameService.AddCreatedAtPrefix(fileInfo);
                    break;
                case "/C":
                    this.RenameService.AddCreatedAtPostfix(fileInfo);
                    break;
                case "/u":
                    this.RenameService.AddUpdatedAtPrefix(fileInfo);
                    break;
                case "/U":
                    this.RenameService.AddUpdatedAtPostfix(fileInfo);
                    break;
                case "/rc":
                    this.RenameService.ReplaceCreatedAtPrefix(fileInfo);
                    break;
            }
        }
    }
}
