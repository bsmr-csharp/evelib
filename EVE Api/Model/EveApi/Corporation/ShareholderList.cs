﻿using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class ShareholderList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<Shareholder> Shareholders { get; set; }


        [Serializable]
        [XmlRoot("row")]
        public class Shareholder {
            
            [XmlAttribute("shareholderID")]
            public long ShareholderId { get; set; }

            [XmlAttribute("shareholderName")]
            public string ShareholderName { get; set; }

            [XmlAttribute("shares")]
            public int Shares { get; set; }

            [XmlAttribute("shareholderCorporationID")]
            public long ShareholderCorporationId { get; set; }

            [XmlAttribute("shareholderCorporationName")]
            public string ShareholderCorporationName { get; set; }

        }
    }
}
