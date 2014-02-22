﻿using eZet.Eve.EoLib.Dto.EveApi;
using eZet.Eve.EoLib.Util;

namespace eZet.Eve.EoLib.Test {
    public class TestSerializer : IXmlSerializer {
        public XmlResponse<T> Deserialize<T>(string data) where T : XmlElement {
            return new XmlResponse<T>();
        }
    }
}