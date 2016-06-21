namespace ContextRenamer.Service
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// TestOptionService のテスト クラスです。
    /// </summary>
    [TestClass]
    public class TestOptionService
    {
        /// <summary>
        /// OptionService コンストラクタ のテスト
        /// </summary>
        [TestMethod]
        public void OptionServiceConstructorTest()
        {
            Assert.AreNotEqual(null, new OptionService());
        }

        /// <summary>
        /// Dispatch のテスト
        /// </summary>
        [TestMethod]
        public void DispatchTest001()
        {
            var mock = new Mock<RenameService>();

            var target = new OptionServiceTestable();
            target.SetRenameService(mock.Object);

            target.Dispatch("/c", @"t:\test\test.txt");

            mock.Verify(m => m.AddCreatedAtPrefix(It.IsAny<FileInfo>()));
        }

        /// <summary>
        /// Dispatch のテスト
        /// </summary>
        [TestMethod]
        public void DispatchTest002()
        {
            var mock = new Mock<RenameService>();

            var target = new OptionServiceTestable();
            target.SetRenameService(mock.Object);

            target.Dispatch("/C", @"t:\test\test.txt");

            mock.Verify(m => m.AddCreatedAtPostfix(It.IsAny<FileInfo>()));
        }

        /// <summary>
        /// Dispatch のテスト
        /// </summary>
        [TestMethod]
        public void DispatchTest003()
        {
            var mock = new Mock<RenameService>();

            var target = new OptionServiceTestable();
            target.SetRenameService(mock.Object);

            target.Dispatch("/u", @"t:\test\test.txt");

            mock.Verify(m => m.AddUpdatedAtPrefix(It.IsAny<FileInfo>()));
        }

        /// <summary>
        /// Dispatch のテスト
        /// </summary>
        [TestMethod]
        public void DispatchTest004()
        {
            var mock = new Mock<RenameService>();

            var target = new OptionServiceTestable();
            target.SetRenameService(mock.Object);

            target.Dispatch("/U", @"t:\test\test.txt");

            mock.Verify(m => m.AddUpdatedAtPostfix(It.IsAny<FileInfo>()));
        }

        /// <summary>
        /// Dispatch のテスト
        /// </summary>
        [TestMethod]
        public void DispatchTest005()
        {
            var mock = new Mock<RenameService>();

            var target = new OptionServiceTestable();
            target.SetRenameService(mock.Object);

            target.Dispatch("/rc", @"t:\test\test.txt");

            mock.Verify(m => m.ReplaceCreatedAtPrefix(It.IsAny<FileInfo>()));
        }

        public class OptionServiceTestable : OptionService
        {
            public void SetRenameService(RenameService renameService)
            {
                this.RenameService = renameService;
            }
        }
    }
}