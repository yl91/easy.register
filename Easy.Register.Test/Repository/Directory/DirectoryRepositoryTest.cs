﻿using System.Linq;
using NUnit.Framework;
namespace Easy.Register.Test.Repository.Directory
{

    public class DirectoryRepositoryTest
    {
        [Test]
        public void AddTest()
        {

            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            Assert.IsTrue(expected.Id > 0);

            var actual = Model.RepositoryRegistry.Directory.FindBy(expected.Id);

            DirectoryAssert(expected, actual);
        }
        [Test]
        public void DirectoryIsExistsTest()
        {
            var expected = Create();
            Model.RepositoryRegistry.Directory.Add(expected);

            var result  = Model.RepositoryRegistry.Directory.DirectoryIsExists(expected);
            Assert.IsFalse(result);
        }
        [Test]
        public void SelectTest()
        {
            var expected = Create(Model.DirectoryType.提供者);
            Model.RepositoryRegistry.Directory.Add(expected);
            var expected2 = Create(Model.DirectoryType.消费者);
            Model.RepositoryRegistry.Directory.Add(expected2);

            var expected3 = Create(Model.DirectoryType.消费者提供者);
            Model.RepositoryRegistry.Directory.Add(expected3);

            var result = Model.RepositoryRegistry.Directory.Select(Model.DirectoryType.提供者);
            Assert.AreEqual(2, result.Count());
            result = Model.RepositoryRegistry.Directory.Select(Model.DirectoryType.消费者);
            Assert.AreEqual(2, result.Count());

        }

        [TearDown]
        public void Clear()
        {
            Model.RepositoryRegistry.Directory.RemoveAll();
        }


        void DirectoryAssert(Model.Directory expected, Model.Directory actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PingAPIPath, actual.PingAPIPath);
            Assert.AreEqual(expected.VersionAPIPath, actual.VersionAPIPath);
            Assert.AreEqual(expected.DirectoryType, actual.DirectoryType);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.CreateDate.Hour, actual.CreateDate.Hour);
        }

        public static Model.Directory Create(Model.DirectoryType directoryType = Model.DirectoryType.提供者)
        {
            var directory = new Model.Directory("订单服务")
            {
                Description = "sdfkfjsdlf",
                DirectoryType = directoryType,
                PingAPIPath = "/adfaf/adff",
                VersionAPIPath = "/dfadfadf/adfad",
            };

            return directory;
        }
    }
}