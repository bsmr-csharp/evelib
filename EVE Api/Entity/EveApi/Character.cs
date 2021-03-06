﻿using System;
using System.Runtime.CompilerServices;
using eZet.Eve.EveLib.Model.EveApi;
using eZet.Eve.EveLib.Model.EveApi.Character;
using eZet.Eve.EveLib.Model.EveApi.Core;

[assembly: InternalsVisibleTo("EveLib.Tests")]


namespace eZet.Eve.EveLib.Entity.EveApi {

    /// <summary>
    /// Provides access to all API calls relating to a specific character, that is, URIs prefixed with /char in CCPs API.
    /// </summary>
    public class Character : BaseEntity {

        /// <summary>
        /// The Wallet identifier. For characters this is always 1000.
        /// </summary>
        public const int AccountKey = 1000;

        /// <summary>
        /// The API key used for this character.
        /// </summary>
        public ApiKey Key { get; private set; }

        /// <summary>
        /// The id of this character.
        /// </summary>
        public long CharacterId { get; private set; }

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string CharacterName { get; private set; }

        /// <summary>
        /// Creates a new object using the proided key and character id.
        /// </summary>
        /// <param name="key">A valid key.</param>
        /// <param name="characterId">A character id exposed by the provided key.</param>
        /// <param name="characterName"></param>
        internal Character(ApiKey key, long characterId, string characterName) {
            Key = key;
            CharacterId = characterId;
            CharacterName = characterName;
            UriBase = new Uri("https://api.eveonline.com");
        }

        
        /// <summary>
        /// Returns general information about the character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CharacterInfo> GetCharacterInfo() {
            const string relPath = "/eve/CharacterInfo.xml.aspx";
            return request(new CharacterInfo(), relPath, Key, "characterID", CharacterId);
        }

        /// <summary>
        /// Returns the ISK balance of a character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AccountBalance> GetAccountBalance() {
            const string relPath = "/char/AccountBalance.xml.aspx";
            return request(new AccountBalance(), relPath, Key, "characterID", CharacterId);
        }

        /// <summary>
        /// Returns a list of assets owned by a character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<AssetList> GetAssetList() {
            const string relPath = "/char/AssetList.xml.aspx";
            return request(new AssetList(), relPath, Key, "characterID", CharacterId);
        }

        /// <summary>
        /// Returns a list of all invited attendees for a given event.
        /// <para> </para>
        /// NOTE: A call to Upcoming Calendar Events must be made prior to calling this API. Otherwise you will receive an error: 
        /// <para> </para>
        /// 216: Calendar Event List not populated with upcoming events. You cannot request any random eventID.
        /// </summary>
        /// <param name="eventId">The id of the event.</param>
        /// <returns></returns>
        public XmlResponse<CalendarEventAttendees> GetCalendarEventAttendees(long eventId) {
            const string relPath = "/char/CalendarEventAttendees.xml.aspx";
            return request(new CalendarEventAttendees(), relPath, Key, "characterID", CharacterId, "EventIDs", eventId);
        }

        /// <summary>
        /// Returns attributes relating to a specific character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<CharacterSheet> GetCharacterSheet() {
            const string relPath = "/char/CharacterSheet.xml.aspx";
            return request(new CharacterSheet(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the character's contact and watch lists, incl. agents and respective standings set by the character. Also includes that character's corporation and/or alliance contacts.
        /// <para></para>
        /// See the Standings API for standings towards the character from agents and NPC entities.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContactList> GetContactList() {
            const string relPath = "/char/ContactList.xml.aspx";
            return request(new ContactList(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Lists the notifications received about having been added to someone's contact list.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContactNotifications> GetContactNotifications() {
            const string relPath = "/char/ContactNotifications.xml.aspx";
            return request(new ContactNotifications(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Lists the personal contracts for a character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractList> GetContracts() {
            const string relPath = "/char/Contracts.xml.aspx";
            return request(new ContractList(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Lists items that a specified contract contains.
        /// </summary>
        /// <param name="contractId">A contract id.</param>
        /// <returns></returns>
        public XmlResponse<ContractItems> GetContractItems(long contractId) {
            const string relPath = "/char/ContractItems.xml.aspx";
            return request(new ContractItems(), relPath, Key, "characterId", CharacterId, "contractID", contractId);
        }

        /// <summary>
        /// Lists the latest bids that have been made to any recent auctions.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<ContractBids> GetContractBids() {
            const string relPath = "/char/ContractBids.xml.aspx";
            return request(new ContractBids(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// If the character is enlisted in Factional Warfare, this will return statistics regarding factional warfare for this character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Model.EveApi.Character.FactionWarfareStats> GetFactionWarfareStats() {
            const string relPath = "/char/FacWarStats.xml.aspx";
            return request(new Model.EveApi.Character.FactionWarfareStats(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the characters industry jobs.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<IndustryJobs> GetIndustryJobs() {
            const string relPath = "/char/IndustryJobs.xml.aspx";
            return request(new IndustryJobs(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns a list of kills where this character received the final blow and losses of this character. 
        /// <para></para>
        /// Returns the 25 most recent kills. You can scroll back with the killId parameter.
        /// </summary>
        /// <param name="killId">Optional; if present, return the most recent kills before the specified killID.</param>
        /// <returns></returns>
        public XmlResponse<KillLog> GetKillLog(long killId = 0) {
            // TODO Add walking
            const string relPath = "/char/KillLog.xml.aspx";
            return killId != 0
                ? request(new KillLog(), relPath, Key, "characterId", CharacterId, "beforeKillId", killId)
                : request(new KillLog(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Call will return the items name (or its type name if no user defined name exists) as well as their x,y,z coordinates.
        /// <para></para>
        /// Coordinates should all be 0 for valid locations located inside of stations.
        /// </summary>
        /// <param name="list">A list of item ids.</param>
        /// <returns></returns>
        public XmlResponse<Locations> GetLocations(params long[] list) {
            const string relPath = "/char/Locations.xml.aspx";
            var ids = String.Join(",", list);
            return request(new Locations(), relPath, Key, "characterId", CharacterId, "IDs", ids);

        }

        /// <summary>
        /// Returns the bodies of headers that have already been fetched with the MailMessages call. 
        /// <para></para>
        /// It will also return a list of missing IDs that could not be accessed. Bodies cannot be accessed if you have not called for their headers recently.
        /// </summary>
        /// <param name="list">A list of message ids from GetMailMessages.</param>
        /// <returns></returns>
        public XmlResponse<MailBodies> GetMailBodies(params long[] list) {
            const string relPath = "/char/MailBodies.xml.aspx";
            var ids = String.Join(",", list);
            return request(new MailBodies(), relPath, Key, "characterId", CharacterId, "IDs", ids);
        }

        /// <summary>
        /// Returns an XML document listing all mailing lists the character is currently a member of.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MailingLists> GetMailingLists() {
            const string relPath = "/char/mailinglists.xml.aspx";
            return request(new MailingLists(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the message headers for mail.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MailMessages> GetMailMessages() {
            const string relPath = "/char/MailMessages.xml.aspx";
            return request(new MailMessages(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns a list of market orders for your character.
        /// </summary>
        /// <param name="orderId">Optional; market order ID to fetch an order that is no longer open.</param>
        /// <returns></returns>
        public XmlResponse<MarketOrders> GetMarketOrders(long orderId = 0) {
            const string relPath = "/char/MarketOrders.xml.aspx";
            return orderId == 0
                ? request(new MarketOrders(), relPath, Key, "characterId", CharacterId)
                : request(new MarketOrders(), relPath, Key, "characterId", CharacterId, "orderID", orderId);
        }

        /// <summary>
        /// Returns a list of medals the character has.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<MedalList> GetMedals() {
            const string relPath = "/char/Medals.xml.aspx";
            return request(new MedalList(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the message headers for notifications.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<NotificationList> GetNotifications() {
            const string relPath = "/char/Notifications.xml.aspx";
            return request(new NotificationList(), relPath, Key, "characterId", CharacterId);
        }


        /// <summary>
        /// Returns the message bodies for notifications. Headers need to be requested with GetNotifications first.
        /// </summary>
        /// <param name="ids">A list of notification ids obtained from GetNotifications.</param>
        /// <returns></returns>
        public XmlResponse<NotificationTexts> GetNotificationTexts(params long[] ids) {
            const string relPath = "/char/NotificationTexts.xml.aspx";
            var idList = string.Join(",", ids);
            return request(new NotificationTexts(), relPath, Key, "characterId", CharacterId, "IDs", idList);
        }

        /// <summary>
        /// Returns information about agents character is doing research with.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<Research> GetResearch() {
            const string relPath = "/char/Research.xml.aspx";
            return request(new Research(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the skill the character is currently training.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<SkillTraining> GetSkillTraining() {
            const string relPath = "/char/SkillInTraining.xml.aspx";
            return request(new SkillTraining(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the skill queue of the character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<SkillQueue> GetSkillQueue() {
            const string relPath = "/char/SkillQueue.xml.aspx";
            return request(new SkillQueue(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns the standings towards a character from agents, NPC corporations and factions.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<StandingsList> GetStandings() {
            const string relPath = "/char/Standings.xml.aspx";
            return request(new StandingsList(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns a list of all upcoming calendar events for a given character.
        /// </summary>
        /// <returns></returns>
        public XmlResponse<UpcomingCalendarEvents> GetUpcomingCalendarEvents() {
            const string relPath = "/char/UpcomingCalendarEvents.xml.aspx";
            return request(new UpcomingCalendarEvents(), relPath, Key, "characterId", CharacterId);
        }

        /// <summary>
        /// Returns a list of journal transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletJournal> GetWalletJournal(int count = 50, long fromId = 0) {
            // TODO add walking
            const string relPath = "/char/WalletJournal.xml.aspx";
            var result = fromId == 0
                ? request(new WalletJournal(), relPath, Key, "characterId", CharacterId, "rowCount", count)
                : request(new WalletJournal(), relPath, Key, "characterId", CharacterId, "rowCount", count, "fromID", fromId);
            result.Result.CharWalker = GetWalletJournal;
            return result;
        }


        /// <summary>
        /// Returns market transactions for the character.
        /// </summary>
        /// <param name="count">Optional; Used for specifying the amount of rows to return. Default is 50. Maximum is 2560.</param>
        /// <param name="fromId">Optional; Used for walking the journal backwards to get more entries.</param>
        /// <returns></returns>
        public XmlResponse<WalletTransactions> GetWalletTransactions(int count = 1000, long fromId = 0) {
            const string relPath = "/char/WalletTransactions.xml.aspx";
            var result = fromId == 0
                ? request(new WalletTransactions(), relPath, Key, "characterId", CharacterId, "rowCount", count)
                : request(new WalletTransactions(), relPath, Key, "characterId", CharacterId, "rowCount", count, "fromID", fromId);
            result.Result.CharWalker = GetWalletTransactions;
            return result;
        }
    }
}