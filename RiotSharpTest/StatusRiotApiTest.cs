using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;
using System;

namespace RiotSharpTest
{
    [TestClass]
    public class StatusRiotApiTest
    {
        private static StatusRiotApi api = StatusRiotApi.GetInstance();
        private static Region region = Region.euw;

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShards_Test()
        {
            var shards = api.GetShards();

            Assert.IsNotNull(shards);
            Assert.IsTrue(shards.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardsAsync_Test()
        {
            var shards = api.GetShardsAsync();

            Assert.IsNotNull(shards.Result);
            Assert.IsTrue(shards.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void GetShardStatus_Test()
        {
            var shardStatus = api.GetShardStatus(region);

            Assert.IsNotNull(shardStatus);
            Assert.AreEqual(region, shardStatus.Slug);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            var shardStatus = api.GetShardStatusAsync(region);

            Assert.IsNotNull(shardStatus.Result);
            Assert.AreEqual(region, shardStatus.Result.Slug);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Interceptor")]
        public void Interceptor_GetShards_Test()
        {
            var requestId1 = Guid.Empty;
            var requestId2 = Guid.Empty;
            string responseRawData = null;

            var beforeSendRequest = new BeforeSendRequestEventHandler(delegate(BeforeSendRequestEventArgs e)
            {
                requestId1 = e.RequestId;
            });

            var afterReceiveReply = new AfterReceiveReplyEventHandler(delegate(AfterReceiveReplyEventArgs e)
            {
                requestId2 = e.RequestId;
                responseRawData = e.ResponseRawData;
            });

            api.BeforeSendRequest += beforeSendRequest;
            api.AfterReceiveReply += afterReceiveReply;

            var shards = api.GetShards();

            Assert.IsNotNull(shards);
            Assert.IsTrue(shards.Count() > 0);
            Assert.AreNotSame(requestId1, Guid.Empty);
            Assert.AreEqual(requestId1, requestId2);
            Assert.IsNotNull(responseRawData);
        }

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async"), TestCategory("Interceptor")]
        public void Interceptor_GetShardsAsync_Test()
        {
            var requestId1 = Guid.Empty;
            var requestId2 = Guid.Empty;
            string responseRawData = null;

            var beforeSendRequest = new BeforeSendRequestEventHandler(delegate(BeforeSendRequestEventArgs e)
            {
                requestId1 = e.RequestId;
            });

            var afterReceiveReply = new AfterReceiveReplyEventHandler(delegate(AfterReceiveReplyEventArgs e)
            {
                requestId2 = e.RequestId;
                responseRawData = e.ResponseRawData;
            });

            api.BeforeSendRequest += beforeSendRequest;
            api.AfterReceiveReply += afterReceiveReply;

            var shards = api.GetShardsAsync();

            Assert.IsNotNull(shards.Result);
            Assert.IsTrue(shards.Result.Count() > 0);
            Assert.AreNotSame(requestId1, Guid.Empty);
            Assert.AreEqual(requestId1, requestId2);
            Assert.IsNotNull(responseRawData);
        }
    }
}
