namespace ContextRenamer.Service
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// RenameService のテスト クラスです。
    /// </summary>
    [TestClass]
    public class TestRenameService
    {
        /// <summary>
        /// RenameService コンストラクタ のテスト
        /// </summary>
        [TestMethod]
        public void RenameServiceTest()
        {
            Assert.AreNotEqual(null, new RenameService());
        }

        /// <summary>
        /// AddCreatedAtPrefix のテスト
        /// </summary>
        [TestMethod]
        public void AddCreatedAtPrefixTest()
        {
            var fileInfo = new FileInfo(@"t:\test\test.txt");
            var target = new RenameServiceTesttable();
            target.AddCreatedAtPrefix(fileInfo);
            Assert.AreEqual(@"16010101_test.txt", target.NewFileName);
        }

        /// <summary>
        /// AddCreatedAtPostfix のテスト
        /// </summary>
        [TestMethod]
        public void AddCreatedAtPostfixTest()
        {
            var fileInfo = new FileInfo(@"t:\test\test.txt");
            var target = new RenameServiceTesttable();
            target.AddCreatedAtPostfix(fileInfo);
            Assert.AreEqual(@"test_16010101.txt", target.NewFileName);
        }

        /// <summary>
        /// AddUpdatedAtPrefix のテスト
        /// </summary>
        [TestMethod]
        public void AddUpdatedAtPrefixTest()
        {
            var fileInfo = new FileInfo(@"t:\test\test.txt");
            var target = new RenameServiceTesttable();
            target.AddUpdatedAtPrefix(fileInfo);
            Assert.AreEqual(@"16010101_test.txt", target.NewFileName);
        }

        /// <summary>
        /// AddUpdatedAtPostfix のテスト
        /// </summary>
        [TestMethod]
        public void AddUpdatedAtPostfixTest()
        {
            var fileInfo = new FileInfo(@"t:\test\test.txt");
            var target = new RenameServiceTesttable();
            target.AddUpdatedAtPostfix(fileInfo);
            Assert.AreEqual(@"test_16010101.txt", target.NewFileName);
        }

        /// <summary>
        /// ReplaceCreatedAtPrefix のテスト
        /// </summary>
        [TestMethod]
        public void ReplaceCreatedAtPrefixTest()
        {
            var fileInfo = new FileInfo(@"t:\test\20130702_test.txt");
            var target = new RenameServiceTesttable();
            target.ReplaceCreatedAtPrefix(fileInfo);
            Assert.AreEqual(@"16010101_test.txt", target.NewFileName);
        }

        /// <summary>
        /// RenameService のテスト用クラス
        /// </summary>
        public class RenameServiceTesttable : RenameService
        {
            public string NewFileName { get; set; }

            public override void Rename(FileInfo fileInfo, string newFileName)
            {
                this.NewFileName = newFileName;
            }
        }
    }
}