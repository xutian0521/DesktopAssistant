using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Com
{
    public  class XmlHelper
    {
        /// <summary>
        /// 载入界面字符串xml文件
        /// </summary>
        private static XDocument xStrDoc = XDocument.Load("../../xml/PromptString.xml");
        private static XDocument xSysDoc = XDocument.Load("../../xml/SystemConfig.xml");
        /// <summary>
        /// 载入系统配置xml文件的根元素
        /// </summary>
        private XElement xSysRoot = xSysDoc.Root;
        /// <summary>
        /// 界面提示字符串跟元素
        /// </summary>
        private XElement xStrRoot;
        public static string LanguageType;
        /// <summary>
        /// 根据配置文件初始化界面提示字符串
        /// </summary>
        public XmlHelper()
        {
            LanguageType = xSysRoot.Element("Language").Value;
            IEnumerable<XElement> XElements = xStrDoc.Root.Elements();
            XElement resultXele = null;
            foreach (var item in XElements)
            {
                if (item.Attribute("Language").Value == LanguageType)
                {
                    resultXele = item;
                }

            }
            xStrRoot = resultXele;
        }
        


        /// <summary>
        /// 查询PromptString元素名字为name的值
        /// </summary>
        /// <param name="name">要查询元素的名字</param>
        /// <returns></returns>
        public string GetElementValue(string name)
        {
            return xStrRoot.Element(name).Value;
        }
        public bool SetLanguage(string language)
        {
            xSysRoot.Element("Language").Value = language;
            xSysDoc.Save("../../xml/SystemConfig.xml");
            return true;
        }
    }
}
