﻿using System;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Corporation {

    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class OutpostList : XmlElement {

        [XmlElement("rowset")]
        public XmlRowSet<Outpost> Outposts { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Outpost {
            
            [XmlAttribute("stationID")]
            public long StationId { get; set; }

            [XmlAttribute("ownerID")]
            public long OwnerId { get; set; }

            [XmlAttribute("stationName")]
            public string StationName { get; set; }

            [XmlAttribute("solarSystemID")]
            public long SolarSystemId { get; set; }

            [XmlAttribute("dockingCostPerShipVolume")]
            public decimal DockingCost { get; set; }

            [XmlAttribute("officeRentalCost")]
            public decimal OfficeRentalCost { get; set; }

            [XmlAttribute("stationTypeID")]
            public long StationTypeId { get; set; }

            [XmlAttribute("reprocessingEfficiency")]
            public double ReprocessingEfficiency { get; set; }

            [XmlAttribute("reprocessingStationTake")]
            public double ReprocessingStationTake { get; set; }

            [XmlAttribute("standingOwnerID")]
            public long StandingOwnerId { get; set; }
        }
    }
}
