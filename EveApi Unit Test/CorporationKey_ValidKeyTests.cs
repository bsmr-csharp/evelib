﻿using eZet.Eve.EveLib.Entity;
using eZet.Eve.EveLib.Entity.EveApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {

    [TestClass]
    public class CorporationKey_ValidKeyTests {
        
        private const int CorpId = 3120830;

        private const string CorpCode = "Zw1DpOUDPYrv49iGTVkDHoRburv2rAAYEbret9B5IVfcVjVDR4DE2bo7p1RMZQMU";

        private readonly CorporationKey validKey = new CorporationKey(CorpId, CorpCode);

        [TestMethod]
        public void Corporation_ValidRequest_HasName() {
            Assert.IsNotNull(validKey.Corporation.CorporationName);
        }

        [TestMethod]
        public void GetAccountBalance_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetAccountBalance();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetAssetList_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetAssetList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContactList_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetContactList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContainerLog_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetContainerLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContracts_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetContracts();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetContractItems_InvalidId_HasError() {
            var res = validKey.Corporation.GetContractItems(0);
            Assert.IsNotNull(res.Error, "API returns statuscode 500 instead of 403 with error code.");
            // BUG Returns http 500 on invalid id
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetContractBids_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetContractBids();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetCorporationSheet_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetCorporationSheet();
            Assert.IsNotNull(res.Result);
        }

        /// <summary>
        /// Test using character that has not participated in factional warfare
        /// </summary>
        [TestMethod]
        public void GetFactionalWarfareStats_InvalidRequest_HasError() {
            var res = validKey.Corporation.GetFactionWarfareStats();
            Assert.IsNotNull(res.Error);
        }

        [TestMethod]
        public void GetIndustryJobs_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetIndustryJobs();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetKillLog_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetKillLog();
            Assert.IsNotNull(res.Result);
            // TODO Test this further
        }

        [TestMethod]
        public void GetLocations_InvalidId_HasError() {
            var res = validKey.Corporation.GetLocations(0);
            Assert.IsNotNull(res.Error);
        }

        [TestMethod]
        public void GetMarketOrders_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMarketOrders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMedals_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberMedals_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMemberMedals();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurity_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMemberSecurity();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberSecurityLog_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMemberSecurityLog();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetMemberTracking_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetMemberTracking(true);
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetOutpostList_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetOutpostList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetOutpostServiceDetails_InvalidId_HasError() {
            var res = validKey.Corporation.GetOutpostServiceDetails(0);
            Assert.IsNotNull(res.Error, "Returns http 200 and an empty result instead of error.");
            // BUG Returns http 200 and empty Result on invalid ID
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetShareholders_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetShareholders();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStandings_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetStandings();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetStarbaseDetails_InvalidId_HasError() {
            var res = validKey.Corporation.GetStarbaseDetails(0);
            Assert.IsNotNull(res.Error);
            // TODO Add valid ID test
        }

        [TestMethod]
        public void GetStarbaseList_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetStarbaseList();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetTitles_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetTitles();
            Assert.IsNotNull(res.Result);
        }

        [TestMethod]
        public void GetWalletJournal_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetWalletJournal(1001, 5);
            Assert.IsNotNull(res.Result);
            //var older = res.Result.GetOlder(50);
        }

        [TestMethod]
        public void GetWalletTransactions_ValidRequest_HasResult() {
            var res = validKey.Corporation.GetWalletTransactions(50);
            Assert.IsNotNull(res.Result);
            //res = res.Result.GetOlder(50);
        }
    }
}
